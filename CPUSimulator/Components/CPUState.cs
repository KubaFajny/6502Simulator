using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator
{
    public enum StatusFlag { Carry, Zero, InterruptDisable, Decimal, Break, Unused, Overflow, Negative }

    public enum InterruptType
    {
        Reset, // a reset signal, level-triggered
        NMI,   // a non-maskable interrupt, edge-triggered
        IRQ    // a maskable interrupt, level-triggered
    }

    /// <summary>
    /// Encapsulates all variables controlling processor registers and flags for interrupts invocation.
    /// </summary>
    public class CPUState
    {
        public byte Accumulator;
        public byte RegisterX;
        public byte RegisterY;
        public byte SP; // Stack Pointer
        public ushort PC; // Program Counter
        public byte Status;

        // Interrupts
        public bool NmiInvoked;
        public bool IrqInvoked;

        public bool IsRunning;

        /// <summary>
        /// Constructs an new CPUState instance with the Stack Pointer pointed to the 0xFF address.
        /// </summary>
        public CPUState()
        {
            Status = 0;
            SP = 0xFF; // The stack grows downward, so set the Stack Pointer register at the address 255
        }

        /// <summary>
        /// Changes the Status register by setting or clearing the given status flag.
        /// </summary>
        /// <param name="statusFlag">The status flag to be set/cleared.</param>
        /// <param name="set">The flag will be set if true and cleared if false.</param>
        public void ChangeStatusFlag(StatusFlag statusFlag, bool set = false)
        {
            if (!set)
                Status &= (byte) ~(1 << (byte)statusFlag);
            else
                Status |= (byte) (1 << (byte) statusFlag);
        }

        /// <summary>
        /// Checks if the given status flag is set.
        /// </summary>
        /// <param name="statusFlag">The flag to be checked.</param>
        /// <returns>True if the flag is set, otherwise false.</returns>
        public bool HasStatusFlag(StatusFlag statusFlag)
        {
            return (Status & (1 << (byte)statusFlag)) != 0;
        }
    }
}
