using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator.Operations
{
    /// <summary>
    /// Implements the Operation for the PHA instruction.
    /// </summary>
    class OperationPHA : Operation
    {
        public OperationPHA() {}

		protected OperationPHA(Instruction instruction, byte[] operand, ushort address) : base(instruction, operand, address) {}

		public override Operation Clone(Instruction instruction, byte[] operand, ushort address) {
			return new OperationPHA(instruction, operand, address);
		}

        public override void Execute(CPUState state, Bus bus)
        {
            bus.StackPush(state, state.Accumulator);
        }
    }
}
