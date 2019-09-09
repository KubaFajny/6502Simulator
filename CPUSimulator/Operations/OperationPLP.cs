using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator.Operations
{
    /// <summary>
    /// Implements the Operation for the PLP instruction.
    /// </summary>
    class OperationPLP : Operation
    {
        public OperationPLP() {}

		protected OperationPLP(Instruction instruction, byte[] operand, ushort address) : base(instruction, operand, address) {}

		public override Operation Clone(Instruction instruction, byte[] operand, ushort address) {
			return new OperationPLP(instruction, operand, address);
		}

        public override void Execute(CPUState state, Bus bus)
        {
            state.Status = bus.StackPop(state);
        }
    }
}
