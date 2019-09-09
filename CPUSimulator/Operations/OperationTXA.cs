using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator.Operations
{
    /// <summary>
    /// Implements the Operation for the TXA instruction.
    /// </summary>
    class OperationTXA : Operation
    {
        public OperationTXA() {}

		protected OperationTXA(Instruction instruction, byte[] operand, ushort address) : base(instruction, operand, address) {}

		public override Operation Clone(Instruction instruction, byte[] operand, ushort address) {
			return new OperationTXA(instruction, operand, address);
		}

        public override void Execute(CPUState state, Bus bus)
        {
            state.Accumulator = state.RegisterX;
            CheckZeroFlag(state, state.Accumulator);
            CheckNegativeFlag(state, state.Accumulator);
        }
    }
}
