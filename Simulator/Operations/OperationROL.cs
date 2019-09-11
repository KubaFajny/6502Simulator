using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator.Operations
{
    /// <summary>
    /// Implements the Operation for the ROL instruction.
    /// </summary>
    class OperationROL : Operation
    {
        public OperationROL() {}

		protected OperationROL(Instruction instruction, byte[] operand, ushort address) : base(instruction, operand, address) {}

		public override Operation Clone(Instruction instruction, byte[] operand, ushort address) {
			return new OperationROL(instruction, operand, address);
		}

        public override void Execute(CPUState state, Bus bus)
        {
            short result;
            int carryBit = state.HasStatusFlag(StatusFlag.Carry) ? 1 : 0;
            if (Instruction.AddressMode != AddressMode.Accumulator)
            {
                int effectiveAddress = CalculateEffectiveAddress(state, bus);
                byte operandValue = bus.Read(effectiveAddress);
                result = (short) ((operandValue << 1) | carryBit); // Set the carry bit in the shifted value via bitwise OR
                bus.Write(effectiveAddress, (byte)result);
            }
            else
            {
                result = (short)((state.Accumulator << 1) | carryBit); // Set the carry bit in the shifted value via bitwise OR
                state.Accumulator = (byte)result;
            }

            CheckNegativeFlag(state, (byte)result);
            CheckZeroFlag(state, result);
            state.ChangeStatusFlag(StatusFlag.Carry, result >> 8 == 1); // Set carry flag depending on whether the highest bit is 1 or not
        }
    }
}
