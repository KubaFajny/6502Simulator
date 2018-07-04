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

            operation.Execute(state, bus);

            // Simulate processor speed
            Thread.Sleep(operation.GetInstruction().GetClockCycles() * CLOCK_PERIOD);
        }

        public void RunAll(short startAddress)
        {
            state.PC = startAddress;
            do
                RunNext();
            while (lastOpcode != 0);
        }

        public void Reset(short startAddress)
        {
            state = new CPUState();
            state.PC = startAddress;
            lastOpcode = 0;
        }

        private Operation getNextOperation()
        {
            int opAddress = state.PC;
            byte opcode = lastOpcode = bus.ReadFromMemory(opAddress);
            if (opcode == 0)
                return null;

            Instruction instruction = InstructionSet.GetInstruction((Opcode) opcode);

            byte[] operand = bus.ReadFromMemory(opAddress + 1, instruction.GetOperandSize());
            state.PC = (short) (opAddress + 1 + operand.Length);

            return OperationFactory.CreateOperation(instruction, operand);
        }
    }
}
