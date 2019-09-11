using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Operations
{
    /// <summary>
    /// Implements the Operation for the ORA instruction.
    /// </summary>
    class OperationORA : Operation
    {
        public OperationORA() {}

		protected OperationORA(Instruction instruction, byte[] operand, ushort address) : base(instruction, operand, address) {}

		public override Operation Clone(Instruction instruction, byte[] operand, ushort address) {
			return new OperationORA(instruction, operand, address);
		}

        public override void Execute(CPUState state, Bus bus)
        {
            byte operandValue = GetOperandValue(state, bus);
            int result = state.Accumulator | operandValue;
            CheckNegativeFlag(state, result);
            CheckZeroFlag(state, result);
            state.Accumulator = (byte) result;
        }
    }
}
