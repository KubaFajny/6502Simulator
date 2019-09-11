using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator.Operations
{
    /// <summary>
    /// Implements the Operation for the PHP instruction.
    /// </summary>
    class OperationPHP : Operation
    {
        public OperationPHP() {}

		protected OperationPHP(Instruction instruction, byte[] operand, ushort address) : base(instruction, operand, address) {}

		public override Operation Clone(Instruction instruction, byte[] operand, ushort address) {
			return new OperationPHP(instruction, operand, address);
		}

        public override void Execute(CPUState state, Bus bus)
        {
            bus.StackPush(state, state.Status);
        }
    }
}
