using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    /// <summary>
    /// This abstract class is the superclass of all classes representing an instruction with it's operand that will be executed by the CPU.
    /// Each instruction must have it's own class that inherits from this abstract class and implements the Execute method.
    /// </summary>
    public abstract class Operation
    {
        public ushort Address { private set; get; }

        public Instruction Instruction { private set; get; }

        public byte[] Operand { private set; get; }

        /// <summary>
        /// Constructs an empty Operation instance. Used only in OperationFactory as a prototype for cloning instances.
        /// </summary>
        protected Operation() {}

        /// <summary>
        /// Constructs a new Operation instance with the specified properties.
        /// </summary>
        /// <param name="instruction">The <see cref="Instruction"/> instance holding required info about the instruction.</param>
        /// <param name="operand">The byte array containing the operand value.</param>
        /// <param name="address">The address at which the instruction is stored in the memory.</param>
        protected Operation(Instruction instruction, byte[] operand, ushort address)
        {
            Instruction = instruction;
            Operand = operand;
            Address = address;
        }


        /// <summary>
        /// Clones the Operation. The cloned Operation will have the new specified properties. 
        /// </summary>
        /// <param name="instruction">The <see cref="Instruction"/> instance holding required info about the instruction.</param>
        /// <param name="operand">The byte array containing the operand value.</param>
        /// <param name="address">The address at which the instruction is stored in the memory.</param>
        public abstract Operation Clone(Instruction instruction, byte[] operand, ushort address);

        /// <summary>
        /// Executes the operation, all instructions have their own logic implemented in this method.
        /// </summary>
        /// <param name="state">The CPUState instance containing register values and other state properties of the CPU.</param>
        /// <param name="bus">The Bus instance for accessing devices.</param>
        public abstract void Execute(CPUState state, Bus bus);

        /// <summary>
        /// Calculates an effective address from the operand based on the address mode of the instruction.
        /// </summary>
        /// <param name="state">The CPUState instance containing register values and other state properties of the CPU.</param>
        /// <param name="bus">The Bus instance for accessing devices.</param>
        /// <returns>The effective address in the memory.</returns>
        protected int CalculateEffectiveAddress(CPUState state, Bus bus)
        {
            byte[] addressBytes;
            switch (Instruction.AddressMode)
            {
                case AddressMode.Absolute:
                    return GetUInt16FromBytes(Operand);
                case AddressMode.AbsoluteX:
                    return GetUInt16FromBytes(Operand) + state.RegisterX;
                case AddressMode.AbsoluteY:
                    return GetUInt16FromBytes(Operand) + state.RegisterY;
                case AddressMode.ZeroPage:
                    return Operand[0];
                case AddressMode.ZeroPageX:
                    return Operand[0] + state.RegisterX;
                case AddressMode.ZeroPageY:
                    return Operand[0] + state.RegisterY;
                case AddressMode.Relative:
                    return state.PC + (sbyte)Operand[0]; // Cast the operand to signed byte (offset can be negative - used in branching instructions)
                case AddressMode.Indirect:
                    addressBytes = bus.Read(GetUInt16FromBytes(Operand), 2);
                    return GetUInt16FromBytes(addressBytes);
                case AddressMode.IndirectX:
                    addressBytes = bus.Read(Operand[0] + state.RegisterX, 2);
                    return GetUInt16FromBytes(addressBytes);
                case AddressMode.IndirectY:
                    addressBytes = bus.Read(Operand[0], 2);
                    return GetUInt16FromBytes(addressBytes) + state.RegisterY;
            }

            return 0;
        }

        /// <summary>
        /// Gets the final operand value for this operation.
        /// </summary>
        /// <param name="state">The CPUState instance containing register values and other state properties of the CPU.</param>
        /// <param name="bus">The Bus instance for accessing devices.</param>
        /// <returns>A single byte of data.</returns>
        protected byte GetOperandValue(CPUState state, Bus bus)
        {
            if (Instruction.AddressMode == AddressMode.Implied)
                return 0;

            if (Instruction.AddressMode == AddressMode.Accumulator)
                return state.Accumulator;

            if (Instruction.AddressMode != AddressMode.Immediate)
            {
                int effectiveAddress = CalculateEffectiveAddress(state, bus);
                return bus.Read(effectiveAddress);
            }

            return Operand[0];
        }

        /// <summary>
        /// Checks the specified value and sets the Zero status flag if it is equal to zero, otherwise the flag is cleared.
        /// </summary>
        /// <param name="state">The CPUState instance containing register values and other state properties of the CPU.</param>
        /// <param name="value">The value to be checked.</param>
        protected void CheckZeroFlag(CPUState state, int value)
        {
            state.ChangeStatusFlag(StatusFlag.Zero, value == 0);
        }

        /// <summary>
        /// Checks the highest order bit of the specified 16-bit value and sets the Negative status flag if it is not equal to zero, otherwise the flag is cleared.
        /// </summary>
        /// <param name="state">The CPUState instance containing register values and other state properties of the CPU.</param>
        /// <param name="value">The value to be checked.</param>
        protected void CheckNegativeFlag(CPUState state, int value)
        {
            state.ChangeStatusFlag(StatusFlag.Negative, (value & 0x80) != 0);
        }

        /// <summary>
        /// Compares the specified value with the operand value and sets the Carry status flag if the value is greather or equals than the operand value, otherwise the flag is cleared.
        /// </summary>
        /// <param name="state">The CPUState instance containing register values and other state properties of the CPU.</param>
        /// <param name="value">The value to be compared.</param>
        /// <param name="operandValue">The operand value to be compared.</param>
        protected void CheckCarryFlag(CPUState state, int value, byte operandValue)
        {
            state.ChangeStatusFlag(StatusFlag.Carry, value >= operandValue);
        }

        /// <summary>
        /// Performs some bitwise operations and tests the result. If the result is not equal to zero then the Overflow status flag is set, otherwise the flag is cleared.
        /// More about this here: http://www.righto.com/2012/12/the-6502-overflow-flag-explained.html
        /// </summary>
        /// <param name="state">The CPUState instance containing register values and other state properties of the CPU.</param>
        /// <param name="value">A value to be used in the bitwise operations.</param>
        /// <param name="operandValue">An operand value to be used in the bitwise operations.</param>
        /// <param name="result">A result from the CPU operation.</param>
        protected void CheckOverflowFlag(CPUState state, int value, byte operandValue, int result)
        {
            state.ChangeStatusFlag(StatusFlag.Overflow, ((value ^ result) & (operandValue ^ result) & 0x80) != 0);
        }

        /// <summary>
        /// Gets the operand as a pretty string.
        /// </summary>
        /// <returns>The string with pretty format.</returns>
        public string GetOperandPretty()
        {
            return Instruction.GetOperandPretty(Operand);
        }

        /// <summary>
        /// Checks whether this operation changes the memory.
        /// Instructions with Accumulator addressing mode never change the memory.
        /// </summary>
        /// <returns>True if the operation changes the memory, otherwise false.</returns>
        public bool ChangesMemory()
        {
            if (Instruction.AddressMode == AddressMode.Accumulator)
                return false;

            switch (Instruction.OpcodeName)
            {
                case "INC":
                case "LSR":
                case "PHA":
                case "PHP":
                case "ROL":
                case "ROR":
                case "STA":
                case "STX":
                case "STY":
                case "ASL":
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Helper method to convert Little Endian byte array to uint16. Should be faster than using BitConverter class.
        /// </summary>
        /// <param name="bytes">The bytes to convert.</param>
        /// <returns>The resulting uint16 value.</returns>
        protected ushort GetUInt16FromBytes(byte[] bytes) {
            ushort val = bytes[1];
            val <<= 8;
            val |= bytes[0];
            return val;
        }
    }
}
