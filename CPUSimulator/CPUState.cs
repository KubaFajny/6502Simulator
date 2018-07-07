using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator
{
    public enum StatusFlag { Carry, Zero, Interrupt, Decimal, Break, Unused, Overflow, Negative }

    public class CPUState
    {
        public byte accumulator;
        public byte registerX;
        public byte registerY;
        public byte SP; // Stack Pointer
        public short PC; // Program Counter
        public byte status;

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
