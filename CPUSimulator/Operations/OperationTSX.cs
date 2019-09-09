using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator.Operations
{
    /// <summary>
    /// Implements the Operation for the TSX instruction.
    /// </summary>
    class OperationTSX : Operation
    {
        public OperationTSX() {}

		protected OperationTSX(Instruction instruction, byte[] operand, ushort address) : base(instruction, operand, address) {}

		public override Operation Clone(Instruction instruction, byte[] operand, ushort address) {
			return new OperationTSX(instruction, operand, address);
		}

        public override void Execute(CPUState state, Bus bus)
        {
            state.RegisterX = state.SP;
            CheckZeroFlag(state, state.RegisterX);
            CheckNegativeFlag(state, state.RegisterX);
        }
    }
}
