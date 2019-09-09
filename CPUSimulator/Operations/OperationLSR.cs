using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator.Operations
{
    /// <summary>
    /// Implements the Operation for the LSR instruction.
    /// </summary>
    class OperationLSR : Operation
    {
        public OperationLSR() {}

		protected OperationLSR(Instruction instruction, byte[] operand, ushort address) : base(instruction, operand, address) {}

		public override Operation Clone(Instruction instruction, byte[] operand, ushort address) {
			return new OperationLSR(instruction, operand, address);
		}

        public override void Execute(CPUState state, Bus bus)
        {
            byte result;
            if (Instruction.AddressMode != AddressMode.Accumulator)
            {
                int effectiveAddress = CalculateEffectiveAddress(state, bus);
                byte operandValue = bus.Read(effectiveAddress);
                state.ChangeStatusFlag(StatusFlag.Carry, (operandValue & 1) == 1); // The lowest bit is displaced by the left shift and stored as carry flag
                result = (byte)(operandValue >> 1);
                bus.Write(effectiveAddress, result);
            }
            else
            {
                state.ChangeStatusFlag(StatusFlag.Carry, (state.Accumulator & 1) == 1); // The lowest bit is displaced by the left shift and stored as carry flag
                result = (byte)(state.Accumulator >> 1);
                state.Accumulator = result;
            }

            CheckZeroFlag(state, result);
        }
    }
}
