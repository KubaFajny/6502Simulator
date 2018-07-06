using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator.Operations
{
    class OperationROL : Operation
    {
        public OperationROL(Instruction instruction, byte[] operand) : base(instruction, operand) { }

        public override void Execute(CPUState state, Bus bus)
        {
            short result;
            int carryBit = state.HasStatusFlag(StatusFlag.Carry) ? 1 : 0;
            if (instruction.GetAddressMode() != AddressMode.Accumulator)
            {
                int effectiveAddress = CalculateEffectiveAddress(state, bus);
                byte operandValue = bus.ReadFromMemory(effectiveAddress);
                result = (short) (operandValue << 1 | carryBit); // Set the carry bit in the shifted value via bitwise OR
                bus.WriteToMemory(effectiveAddress, (byte)result);
            }
            else
            {
                result = (short)(state.accumulator << 1 | carryBit); // Set the carry bit in the shifted value via bitwise OR
                state.accumulator = (byte)result;
            }

            CheckNegativeFlag(state, (byte)result);
            CheckZeroFlag(state, result);
            state.ChangeStatusFlag(StatusFlag.Carry, result >> 8 == 1); // Set carry flag depending on whether the highest bit is 1 or not
        }
    }
}
