using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Operations
{
    /// <summary>
    /// Implements the Operation for the TYA instruction.
    /// </summary>
    class OperationTYA : Operation
    {
        public OperationTYA() {}

		protected OperationTYA(Instruction instruction, byte[] operand, ushort address) : base(instruction, operand, address) {}

		public override Operation Clone(Instruction instruction, byte[] operand, ushort address) {
			return new OperationTYA(instruction, operand, address);
		}

        public override void Execute(CPUState state, Bus bus)
        {
            state.Accumulator = state.RegisterY;
            CheckZeroFlag(state, state.Accumulator);
            CheckNegativeFlag(state, state.Accumulator);
        }
    }
}
