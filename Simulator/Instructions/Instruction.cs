using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public enum AddressMode
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

    /// <summary>
    /// Represents the actual instruction stored in the memory and processed by the CPU.
    /// This class contains basic info about the instruction such as Opcode, OpcodeName, AddressMode or ClockCycles.
    /// </summary>
    public class Instruction
    {
        public Opcode Opcode { private set; get; }

        public AddressMode AddressMode { private set; get; }

        public String OpcodeName { private set; get; }

        public byte ClockCycles { private set; get; }

        /// <summary>
        /// Constructs a new Instruction with the specified properties.
        /// </summary>
        /// <param name="opcode">The opcode of this instruction.</param>
        /// <param name="addressMode">The address mode of this instruction.</param>
        /// <param name="opcodeName">The opcode name of this instruction.</param>
        /// <param name="clockCycles">The clock cycles count of this instruction.</param>
        public Instruction(Opcode opcode, AddressMode addressMode, String opcodeName, byte clockCycles)
        {
            Opcode = opcode;
            AddressMode = addressMode;
            OpcodeName = opcodeName;
            ClockCycles = clockCycles;
        }

        /// <summary>
        /// Gets the operand size based on the addressing mode of this instruction.
        /// </summary>
        /// <returns>The size of this instruction's operand.</returns>
        public byte GetOperandSize()
        {
            switch (AddressMode)
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

        /// <summary>
        /// Converts the instruction operand to a pretty string in the assembler format.
        /// </summary>
        /// <param name="operand">The operand to be converted.</param>
        /// <returns>A string with the operand in the pretty format.</returns>
        public String GetOperandPretty(byte[] operand)
        {
            operand = operand.Reverse().ToArray();
            switch (AddressMode)
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
