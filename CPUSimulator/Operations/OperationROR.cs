using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator.Operations
{
    /// <summary>
    /// Implements the Operation for the ROR instruction.
    /// </summary>
    class OperationROR : Operation
    {
        public OperationROR() {}

		protected OperationROR(Instruction instruction, byte[] operand, ushort address) : base(instruction, operand, address) {}

		public override Operation Clone(Instruction instruction, byte[] operand, ushort address) {
			return new OperationROR(instruction, operand, address);
		}

        public override void Execute(CPUState state, Bus bus)
        {
            byte result;
            int carryBitmask = state.HasStatusFlag(StatusFlag.Carry) ? 0x80 : 0;
            if (Instruction.AddressMode != AddressMode.Accumulator)
            {
                int effectiveAddress = CalculateEffectiveAddress(state, bus);
                byte operandValue = bus.Read(effectiveAddress);
                state.ChangeStatusFlag(StatusFlag.Carry, (operandValue & 1) == 1); // The lowest bit is displaced by the left shift and stored as a carry flag
                result = (byte)((operandValue >> 1) | carryBitmask); // Set the carry bit in the shifted value via bitwise OR
                bus.Write(effectiveAddress, result);
            }
            else
            {
                state.ChangeStatusFlag(StatusFlag.Carry, (state.Accumulator & 1) == 1); // The lowest bit is displaced by the left shift and stored as a carry flag
                result = (byte)((state.Accumulator >> 1) | carryBitmask); // Set the carry bit in the shifted value via bitwise OR
                state.Accumulator = result;
            }

            CheckZeroFlag(state, result);
            CheckNegativeFlag(state, result);
        }
    }
}
