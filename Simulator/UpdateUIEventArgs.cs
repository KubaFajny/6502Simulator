using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    /// <summary>
    /// The UpdateGUIEventArgs are arguments for a UI update event.
    /// </summary>
    public class UpdateUIEventArgs : EventArgs
    {
        /// <summary>
        /// Constructs an empty UpdateUIEventArgs instance.
        /// </summary>
        public UpdateUIEventArgs()
        {
        }


        /// <summary>
        /// Constructs a new UpdateUIEventArgs instance having properties initialized with values from the CPU state and the currently executed Operation.
        /// </summary>
        /// <param name="cpuState">The CPU State instance containing register values and other state properties of the CPU.</param>
        /// <param name="operation">The Operation instance representing the last executed instruction with it's address in the memory and operand value.</param>
        public UpdateUIEventArgs(CPUState cpuState, Operation operation = null)
        {
            RegisterX = cpuState.RegisterX;
            RegisterY = cpuState.RegisterY;
            Accumulator = cpuState.Accumulator;
            StackPointer = cpuState.SP;
            ProgramCounter = cpuState.PC;
            Status = cpuState.Status;
            HasCarryFlag = cpuState.HasStatusFlag(StatusFlag.Carry);
            HasNegativeFlag = cpuState.HasStatusFlag(StatusFlag.Negative);
            HasInterruptDisableFlag = cpuState.HasStatusFlag(StatusFlag.InterruptDisable);
            HasBreakFlag = cpuState.HasStatusFlag(StatusFlag.Break);
            HasDecimalFlag = cpuState.HasStatusFlag(StatusFlag.Decimal);
            HasOverflowFlag = cpuState.HasStatusFlag(StatusFlag.Overflow);
            HasZeroFlag = cpuState.HasStatusFlag(StatusFlag.Zero);

            if (operation != null)
            {
                OperationAddress = operation.Address;
                OperationOpName = operation.Instruction.OpcodeName;
                OperationOperand = operation.GetOperandPretty();
            }
        }

        /// <summary>
        /// Gets the X register content.
        /// </summary>
        public byte RegisterX
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the Y register content.
        /// </summary>
        public byte RegisterY
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the accumulator register content.
        /// </summary>
        public byte Accumulator
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the stack pointer register content.
        /// </summary>
        public byte StackPointer
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the Program Counter register content.
        /// </summary>
        public ushort ProgramCounter
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the status register content.
        /// </summary>
        public byte Status
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the truth value of the Carry status flag.
        /// </summary>
        public bool HasCarryFlag
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the truth value of the Negative status flag.
        /// </summary>
        public bool HasNegativeFlag
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the truth value of the InterruptDisable status flag.
        /// </summary>
        public bool HasInterruptDisableFlag
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the truth value of the Break status flag.
        /// </summary>
        public bool HasBreakFlag
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the truth value of the Decimal status flag.
        /// </summary>
        public bool HasDecimalFlag
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the truth value of the Overflow status flag.
        /// </summary>
        public bool HasOverflowFlag
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the truth value of the Zero status flag.
        /// </summary>
        public bool HasZeroFlag
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the last executed operation's address.
        /// </summary>
        public ushort OperationAddress
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the last executed operation's opcode name.
        /// </summary>
        public string OperationOpName
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the last executed operation's operand.
        /// </summary>
        public string OperationOperand
        {
            get;
            private set;
        }
    }
}
