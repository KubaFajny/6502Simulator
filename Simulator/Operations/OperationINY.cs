using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Operations
{
    /// <summary>
    /// Implements the Operation for the INY instruction.
    /// </summary>
    class OperationINY : Operation
    {
        public OperationINY() {}

		protected OperationINY(Instruction instruction, byte[] operand, ushort address) : base(instruction, operand, address) {}

		public override Operation Clone(Instruction instruction, byte[] operand, ushort address) {
			return new OperationINY(instruction, operand, address);
		}

        public override void Execute(CPUState state, Bus bus)
        {
            state.RegisterY++;
            CheckZeroFlag(state, state.RegisterY);
            CheckNegativeFlag(state, state.RegisterY);
        }
    }
}
