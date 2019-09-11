using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Operations
{
    /// <summary>
    /// Implements the Operation for the LDA instruction.
    /// </summary>
    class OperationLDA : Operation
    {
        public OperationLDA() {}

		protected OperationLDA(Instruction instruction, byte[] operand, ushort address) : base(instruction, operand, address) {}

		public override Operation Clone(Instruction instruction, byte[] operand, ushort address) {
			return new OperationLDA(instruction, operand, address);
		}

        public override void Execute(CPUState state, Bus bus)
        {
            state.Accumulator = GetOperandValue(state, bus);
            CheckZeroFlag(state, state.Accumulator);
            CheckNegativeFlag(state, state.Accumulator);
        }
    }
}
