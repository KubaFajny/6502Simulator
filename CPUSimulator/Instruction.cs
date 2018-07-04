using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator
{
    enum AddressMode
    {
        Accumulator,    // operand is AC (implied single byte instruction)
        Absolute,       // operand is address
        AbsoluteX,      // operand is address; effective address is address incremented by X with carry
        AbsoluteY,      // operand is address; effective address is address incremented by Y with carry
        Immediate,      // operand is byte
        Implied,        // operand implied
        Indirect,       // operand is address; effective address is contents of word at address
        IndirectX,      // operand is zeropage address; effective address is word in (LL + X, LL + X + 1), inc. without carry
        IndirectY,      // operand is zeropage address; effective address is word in (LL, LL + 1) incremented by Y with carry
        Relative,       // branch target is PC + signed offset
        ZeroPage,       // operand is zeropage address
        ZeroPageX,      // operand is zeropage address; effective address is address incremented by X without carry
        ZeroPageY       // operand is zeropage address; effective address is address incremented by Y without carry
    };

   class Instruction
    {
        Opcode opcode;
        AddressMode addressMode;
        String opcodeName;
        byte clockCycles;

        public Instruction(Opcode opcode, AddressMode addressMode, String opcodeName, byte clockCycles)
        {
            this.opcode = opcode;
            this.addressMode = addressMode;
            this.opcodeName = opcodeName;
            this.clockCycles = clockCycles;
        }

        public byte GetOperandSize()
        {
            switch (addressMode)
            {
                case AddressMode.Implied:
                case AddressMode.Accumulator:
                    return 0;
                case AddressMode.IndirectX:
                case AddressMode.IndirectY:
                case AddressMode.Relative:
                case AddressMode.Immediate:
                case AddressMode.ZeroPage:
                case AddressMode.ZeroPageX:
                case AddressMode.ZeroPageY:
                    return 1;
                case AddressMode.Indirect:
                case AddressMode.Absolute:
                case AddressMode.AbsoluteX:
                case AddressMode.AbsoluteY:
                    return 2;
            }

            return 0;
        }

        public byte GetClockCycles()
        {
            return clockCycles;
        }

        public AddressMode GetAddressMode()
        {
            return addressMode;
        }

        public Opcode GetOpcode()
        {
            return opcode;
        }

        public String GetOpcodeName()
        {
            return opcodeName;
        }

        public String GetOperandPretty(byte[] operand)
        {
            switch (addressMode)
            {
                case AddressMode.Absolute:
                    return "$" + BitConverter.ToString(operand).Replace("-", "");
                case AddressMode.AbsoluteX:
                    return "$" + BitConverter.ToString(operand).Replace("-", "") + ",X";
                case AddressMode.AbsoluteY:
                    return "$" + BitConverter.ToString(operand).Replace("-", "") + ",Y";
                case AddressMode.ZeroPage:
                case AddressMode.Relative:
                    return "$" + operand[0].ToString("X2");
                case AddressMode.ZeroPageX:
                    return "$" + operand[0].ToString("X2") + ",X";
                case AddressMode.ZeroPageY:
                    return "$" + operand[0].ToString("X2") + ",Y";
                case AddressMode.Indirect:
                    return "($" + BitConverter.ToString(operand).Replace("-", "") + ")";
                case AddressMode.IndirectX:
                    return "($" + operand[0].ToString("X2") + ",X)";
                case AddressMode.IndirectY:
                    return "($" + operand[0].ToString("X2") + "),Y";
                case AddressMode.Immediate:
                    return "#$" + operand[0].ToString("X2");
            }

            return "";
        }
    }
}
