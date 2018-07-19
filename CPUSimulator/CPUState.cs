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

    public class CPUState
    {
        public byte accumulator;
        public byte registerX;
        public byte registerY;
        public byte SP; // Stack Pointer
        public ushort PC; // Program Counter
        public byte status;

        // Interrupts
        public bool nmiInvoked;
        public bool irqInvoked;

        public CPUState()
        {
            status = 0;
            SP = 0xFF;
        }

        public void ChangeStatusFlag(StatusFlag statusFlag, bool set = false)
        {
            if (!set)
                status &= (byte) ~(1 << (byte)statusFlag);
            else
                status |= (byte) (1 << (byte) statusFlag);
        }

        public bool HasStatusFlag(StatusFlag statusFlag)
        {
            return (status & (1 << (byte)statusFlag)) != 0;
        }
    }
}
