using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator.Operations
{
    /// <summary>
    /// Implements the Operation for the TAY instruction.
    /// </summary>
    class OperationTAY : Operation
    {
        public OperationTAY() {}

		protected OperationTAY(Instruction instruction, byte[] operand, ushort address) : base(instruction, operand, address) {}

		public override Operation Clone(Instruction instruction, byte[] operand, ushort address) {
			return new OperationTAY(instruction, operand, address);
		}

        public override void Execute(CPUState state, Bus bus)
        {
            state.RegisterY = state.Accumulator;
            CheckZeroFlag(state, state.RegisterY);
            CheckNegativeFlag(state, state.RegisterY);
        }
    }
}
