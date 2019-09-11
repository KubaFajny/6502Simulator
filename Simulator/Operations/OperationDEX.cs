using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator.Operations
{
    /// <summary>
    /// Implements the Operation for the DEX instruction.
    /// </summary>
    class OperationDEX : Operation
    {
        public OperationDEX() {}

		protected OperationDEX(Instruction instruction, byte[] operand, ushort address) : base(instruction, operand, address) {}

		public override Operation Clone(Instruction instruction, byte[] operand, ushort address) {
			return new OperationDEX(instruction, operand, address);
		}

        public override void Execute(CPUState state, Bus bus)
        {
            state.RegisterX--;
            CheckZeroFlag(state, state.RegisterX);
            CheckNegativeFlag(state, state.RegisterX);
        }
    }
}
