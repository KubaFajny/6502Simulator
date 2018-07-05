using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator
{
    abstract class Operation
    {
        protected Instruction instruction;
        protected byte[] operand;

        public Operation(Instruction instruction, byte[] operand)
        {
            this.instruction = instruction;
            this.operand = operand;
        }

        public Instruction GetInstruction()
        {
            return instruction;
        }

        public abstract void Execute(CPUState state, Bus bus);

        protected int CalculateEffectiveAddress(CPUState state, Bus bus)
        {
            byte[] addressBytes;
            switch (instruction.GetAddressMode())
            {
                case AddressMode.Absolute:
                    return BitConverter.ToInt16(operand, 0);
                case AddressMode.AbsoluteX:
                    return BitConverter.ToInt16(operand, 0) + state.registerX;
                case AddressMode.AbsoluteY:
                    return BitConverter.ToInt16(operand, 0) + state.registerY;
                case AddressMode.ZeroPage:
                    return operand[0];
                case AddressMode.ZeroPageX:
                    return operand[0] + state.registerX;
                case AddressMode.ZeroPageY:
                    return operand[0] + state.registerY;
                case AddressMode.Relative:
                    return state.PC + (sbyte)operand[0]; // Cast the operand to signed byte (offset can be negative - used in branching instructions)
                case AddressMode.Indirect:
                    addressBytes = bus.ReadFromMemory(BitConverter.ToInt16(operand, 0), 2);
                    return BitConverter.ToInt16(addressBytes, 0);
                case AddressMode.IndirectX:
                    addressBytes = bus.ReadFromMemory(operand[0] + state.registerX, 2);
                    return BitConverter.ToInt16(addressBytes, 0);
                case AddressMode.IndirectY:
                    addressBytes = bus.ReadFromMemory(operand[0] + state.registerX, 2);
                    return BitConverter.ToInt16(addressBytes, 0) + state.registerY;
            }

            return 0;
        }

        protected byte GetOperandValue(CPUState state, Bus bus)
        {
            if (instruction.GetAddressMode() == AddressMode.Implied)
                return 0;

            if (instruction.GetAddressMode() == AddressMode.Accumulator)
                return state.accumulator;

            if (instruction.GetAddressMode() != AddressMode.Immediate)
            {
                int effectiveAddress = CalculateEffectiveAddress(state, bus);
                return bus.ReadFromMemory(effectiveAddress);
            }

            return operand[0];
        }

        protected void CheckZeroFlag(CPUState state, int value)
        {
            state.ChangeStatusFlag(StatusFlag.Zero, value == 0);
        }
    
        protected void CheckNegativeFlag(CPUState state, int value)
        {
            state.ChangeStatusFlag(StatusFlag.Negative, (value & 0x80) != 0);
        }

        protected void CheckCarryFlag(CPUState state, int value, byte operandValue)
        {
            state.ChangeStatusFlag(StatusFlag.Carry, value >= operandValue);
        }

        protected void CheckOverflowFlag(CPUState state, int value, byte operandValue, int result)
        {
            state.ChangeStatusFlag(StatusFlag.Overflow, ((value ^ result) & (operandValue ^ result) & 0x80) != 0);
        }
    }
}
