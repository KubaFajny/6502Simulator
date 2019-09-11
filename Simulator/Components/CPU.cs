using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Simulator
{
    /// <summary>
    /// Simulates the MOS 6502 Processor.
    /// It is capable of executing operations continuosly, executing the next operation, self-resetting and handling interrupts.
    /// The state of the processor is encapsulated in the CPUState instance to make the logic of this class as simple as possible.
    /// The processor is communicating with the outside world via events.
    /// </summary>
    public class CPU
    {
        // How much milliseconds one cycle takes on this processor
        const int CLOCK_PERIOD = 1; // 1MHz = 1000ns = 1ms

        public CPUState State { get; private set; }
        Bus bus;
        byte lastOpcode = 0;
        bool executingOperation = false;
        Dictionary<InterruptType, ushort> interruptHandlers;

        public event Action<Operation> UpdateEvent;
        public event Action StartEvent;
        public event Action StopEvent;

        /// <summary>
        /// Constructs a new CPU instance "wired" with the specified Bus instance.
        /// </summary>
        /// <param name="bus">The Bus instance for accessing other devices.</param>
        public CPU(Bus bus)
        {
            this.bus = bus;
            State = new CPUState();
            interruptHandlers = new Dictionary<InterruptType, ushort>()
            {
                { InterruptType.Reset, 0xFFFC },
                { InterruptType.IRQ,   0xFFFC },
                { InterruptType.NMI,   0xFFFA }
            };
        }

        /// <summary>
        /// Executes the next operation of the program. 
        /// Also handles interrupts, simulates the processor's speed and fires the Update event at the end.
        /// </summary>
        /// <param name="singleStep">The Update event will be fired at the end regardless of the Running state of the CPU.</param>
        public void RunNext(bool singleStep = false)
        {
            // This will delay any stop request. We don't want to stop in the middle of the execution
            executingOperation = true;

            // Backup the current Program Counter for the UI
            ushort currentPC = State.PC;

            // Fetch the next operation - an instruction with its operand
            Operation operation = GetNextOperation();

            // This needs to be done also in a case when no operation was found
            State.PC += 1;

            // No operation fetched? Just end
            if (operation == null)
            {
                executingOperation = false;
                return;
            }

            // Increment the Program Counter by the size of the instruction operand
            // The Program Counter will now point to the next instruction
            State.PC += operation.Instruction.GetOperandSize();

            // And now the fun begins, this actually does all the dirty work
            operation.Execute(State, bus);

            // Simulate the processor's speed
            Thread.Sleep(operation.Instruction.ClockCycles * CLOCK_PERIOD);

            // Handle invoked interrupt requests
            HandleInterrupts();

            // Fire the update event only if the CPU is running or this is only a single step requested by the UI
            if (State.IsRunning || singleStep)
                UpdateEvent(operation);

            // Now any stop request can be processed
            executingOperation = false;
        }

        /// <summary>
        /// Starts an continual execution of the program by looping endlessly until the last opcode is zero or the CPU is stopped externally.
        /// Each loop calls the RunNext method.
        /// </summary>
        public void RunAll()
        {
            Start();
            do
                RunNext();
            while (lastOpcode != 0 && State.IsRunning);

            Stop();
        }

        /// <summary>
        /// Invokes the reset sequence of the processor.
        /// </summary>
        public void InvokeReset()
        {
            // Reset register values
            State = new CPUState();

            // Read the RESET vector and set its contents to the program counter register
            byte[] newAddress = bus.Read(interruptHandlers[InterruptType.Reset], 2);
            State.PC = BitConverter.ToUInt16(newAddress, 0);
            lastOpcode = 0;

            // Update the UI
            UpdateEvent(null);
        }

        /// <summary>
        /// Invokes the NMI interrupt.
        /// </summary>
        public void InvokeNMI()
        {
            State.NmiInvoked = true;
        }

        /// <summary>
        /// Invokes the IRQ interrupt.
        /// </summary>
        public void InvokeIRQ()
        {
            State.IrqInvoked = true;
        }

        /// <summary>
        /// Starts the CPU.
        /// </summary>
        public void Start()
        {
            State.IsRunning = true;
            StartEvent();
        }

        /// <summary>
        /// Stops the CPU.
        /// </summary>
        public void Stop()
        {
            State.IsRunning = false;

            // Is the processor in the middle of execution? Wait until he is done
            if (executingOperation)
                SpinWait.SpinUntil(() => executingOperation);

            StopEvent();
        }

        /// <summary>
        /// Handles processor interrupts by finding the address of the relevant interrupt handler. The program counter is then set to this address.
        /// </summary>
        private void HandleInterrupts()
        {
            // Find the relevant interrupt handler address
            ushort interruptHandler = 0;
            if (State.NmiInvoked)
            {
                interruptHandler = interruptHandlers[InterruptType.NMI];
                State.NmiInvoked = false;
            }
            else if (State.IrqInvoked && !State.HasStatusFlag(StatusFlag.InterruptDisable))
            {
                interruptHandler = interruptHandlers[InterruptType.IRQ];
                State.IrqInvoked = false;
            }

            if (interruptHandler == 0)
                return;

            // Backup contents of the Status and PC register and disable any further interrupt requests for now
            bus.StackPush(State, (byte) (State.PC >> 8)); // Push high byte on the stack
            bus.StackPush(State, (byte) State.PC); // Push low byte on the stack
            bus.StackPush(State, State.Status);
            State.ChangeStatusFlag(StatusFlag.InterruptDisable, true);

            byte[] newAddress = bus.Read(interruptHandler, 2);
            State.PC = BitConverter.ToUInt16(newAddress, 0);
        }

        /// <summary>
        /// Fetches the next operation by reading the single-byte instruction opcode and it's operand.
        /// </summary>
        /// <returns>A new instance of the <see cref="Operation"/> class if an instruction info exists for the read opcode, otherwise null.</returns>
        private Operation GetNextOperation()
        {
            ushort opAddress = State.PC;
            lastOpcode = bus.Read(opAddress);
            Instruction instruction = InstructionSet.GetInstruction((Opcode) lastOpcode);
            if (instruction == null)
                return null;

            byte[] operand = bus.Read(opAddress + 1, instruction.GetOperandSize());
            return OperationFactory.CreateOperation(instruction, operand, opAddress);
        }
    }
}
