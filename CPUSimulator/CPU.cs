using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CPUSimulator
{
    class CPU
    {
        const int CLOCK_PERIOD = 1; // 1MHz = 1000ns = 1ms

        CPUState state;
        Bus bus;
        byte lastOpcode = 0;

        public CPU(Bus bus)
        {
            this.bus = bus;
            state = new CPUState();
        }

        public CPUState GetState()
        {
            return state;
        }

        public void RunNext()
        {
            Operation operation = getNextOperation();
            if (operation == null)
                return;

            state.PC += (ushort) (operation.GetInstruction().GetOperandSize() + 1);
            operation.Execute(state, bus);

            // Simulate processor speed
            Thread.Sleep(operation.GetInstruction().GetClockCycles() * CLOCK_PERIOD);

            handleInterrupts();
        }

        public void RunAll()
        {
            InvokeReset();
            do
                RunNext();
            while (lastOpcode != 0);
        }

        public void InvokeReset()
        {
            state = new CPUState();
            byte[] newAddress = bus.ReadFromMemory(getInterruptHandler(InterruptType.Reset), 2);
            state.PC = BitConverter.ToUInt16(newAddress, 0);
            lastOpcode = 0;
        }

        public void InvokeNMI()
        {
            state.nmiInvoked = true;
        }

        public void InvokeIRQ()
        {
            state.irqInvoked = true;
        }

        private void handleInterrupts()
        {
            ushort interruptHandler = 0;
            if (state.nmiInvoked)
            {
                interruptHandler = getInterruptHandler(InterruptType.NMI);
                state.nmiInvoked = false;
            }
            else if (state.irqInvoked && !state.HasStatusFlag(StatusFlag.InterruptDisable))
            {
                interruptHandler = getInterruptHandler(InterruptType.IRQ);
                state.irqInvoked = false;
            }

            if (interruptHandler == 0)
                return;

            bus.StackPush(state, (byte) (state.PC >> 8)); // Push high byte
            bus.StackPush(state, (byte) state.PC); // Push low byte
            bus.StackPush(state, state.status);
            state.ChangeStatusFlag(StatusFlag.InterruptDisable, true);

            byte[] newAddress = bus.ReadFromMemory(interruptHandler, 2);
            state.PC = BitConverter.ToUInt16(newAddress, 0);
        }

        private ushort getInterruptHandler(InterruptType interrupt)
        {
            switch (interrupt)
            {
                case InterruptType.Reset:
                    return 0xFFFC;
                case InterruptType.IRQ:
                    return 0xFFFE;
                case InterruptType.NMI:
                    return 0xFFFA;
            }

            return 0;
        }

        private Operation getNextOperation()
        {
            int opAddress = state.PC;
            lastOpcode = bus.ReadFromMemory(opAddress);
            Instruction instruction = InstructionSet.GetInstruction((Opcode) lastOpcode);
            byte[] operand = bus.ReadFromMemory(opAddress + 1, instruction.GetOperandSize());

            return OperationFactory.CreateOperation(instruction, operand);
        }
    }
}
