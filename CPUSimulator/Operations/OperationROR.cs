using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator.Operations
{
    class OperationROR : Operation
    {
        public OperationROR(Instruction instruction, byte[] operand) : base(instruction, operand) { }

        public override void Execute(CPUState state, Bus bus)
        {
            byte result;
            int carryBitmask = state.HasStatusFlag(StatusFlag.Carry) ? 0x80 : 0;
            if (instruction.GetAddressMode() != AddressMode.Accumulator)
            {
                int effectiveAddress = CalculateEffectiveAddress(state, bus);
                byte operandValue = bus.ReadFromMemory(effectiveAddress);
                state.ChangeStatusFlag(StatusFlag.Carry, (operandValue & 1) == 1); // The lowest bit is displaced by the left shift and stored as a carry flag
                result = (byte)(operandValue >> 1 | carryBitmask); // Set the carry bit in the shifted value via bitwise OR
                bus.WriteToMemory(effectiveAddress, result);
            }
            else
            {
                state.ChangeStatusFlag(StatusFlag.Carry, (state.accumulator & 1) == 1); // The lowest bit is displaced by the left shift and stored as a carry flag
                result = (byte)(state.accumulator >> 1 | carryBitmask); // Set the carry bit in the shifted value via bitwise OR
                state.accumulator = result;
            }

            CheckZeroFlag(state, result);
        }
    }
}
