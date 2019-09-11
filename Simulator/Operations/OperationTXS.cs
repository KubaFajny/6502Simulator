using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator.Operations
{
    /// <summary>
    /// Implements the Operation for the TXS instruction.
    /// </summary>
    class OperationTXS : Operation
    {
        public OperationTXS() {}

		protected OperationTXS(Instruction instruction, byte[] operand, ushort address) : base(instruction, operand, address) {}

		public override Operation Clone(Instruction instruction, byte[] operand, ushort address) {
			return new OperationTXS(instruction, operand, address);
		}

        public override void Execute(CPUState state, Bus bus)
        {
            state.SP = state.RegisterX;
            CheckZeroFlag(state, state.SP);
            CheckNegativeFlag(state, state.SP);
        }
    }
}
