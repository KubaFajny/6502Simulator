using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Operations
{
    /// <summary>
    /// Implements the Operation for the SBC instruction.
    /// </summary>
    class OperationSBC : Operation
    {
        public OperationSBC() {}

		protected OperationSBC(Instruction instruction, byte[] operand, ushort address) : base(instruction, operand, address) {}

		public override Operation Clone(Instruction instruction, byte[] operand, ushort address) {
			return new OperationSBC(instruction, operand, address);
		}

        public override void Execute(CPUState state, Bus bus)
        {
            // Same as ADC, just used one's complement of the operand
            byte operandValue = (byte) ~GetOperandValue(state, bus);
            int result = state.Accumulator + operandValue + (state.HasStatusFlag(StatusFlag.Carry) ? 1 : 0);

            // TODO: learn how this works: http://www.righto.com/2012/12/the-6502-overflow-flag-explained.html
            CheckOverflowFlag(state, state.Accumulator, operandValue, result);

            // Need to work here with integer result as we need to look at the 9th bit for carry
            state.ChangeStatusFlag(StatusFlag.Carry, (result & 0x100) != 0);

            state.Accumulator = (byte)result;
            CheckNegativeFlag(state, state.Accumulator);
            CheckZeroFlag(state, state.Accumulator);
        }
    }
}
