using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Operations
{
    /// <summary>
    /// Implements the Operation for the BIT instruction.
    /// </summary>
    class OperationBIT : Operation
    {
        public OperationBIT() {}

		protected OperationBIT(Instruction instruction, byte[] operand, ushort address) : base(instruction, operand, address) {}

		public override Operation Clone(Instruction instruction, byte[] operand, ushort address) {
			return new OperationBIT(instruction, operand, address);
		}

        public override void Execute(CPUState state, Bus bus)
        {
            byte operandValue = GetOperandValue(state, bus);
            byte result = (byte) (state.Accumulator & operandValue);

            // Bits 7 and 6 of operand are transfered to bit 7 and 6 of status register (Negative, Overflow)
            state.ChangeStatusFlag(StatusFlag.Negative, (operandValue & 0x80) != 0);
            state.ChangeStatusFlag(StatusFlag.Overflow, (operandValue & 0x40) != 0);

            // The zeroflag is set to the result of operand AND accumulator
            CheckZeroFlag(state, result);
        }
    }
}
