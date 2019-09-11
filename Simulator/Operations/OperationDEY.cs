using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Operations
{
    /// <summary>
    /// Implements the Operation for the DEY instruction.
    /// </summary>
    class OperationDEY : Operation
    {
        public OperationDEY() {}

		protected OperationDEY(Instruction instruction, byte[] operand, ushort address) : base(instruction, operand, address) {}

		public override Operation Clone(Instruction instruction, byte[] operand, ushort address) {
			return new OperationDEY(instruction, operand, address);
		}

        public override void Execute(CPUState state, Bus bus)
        {
            state.RegisterY--;
            CheckZeroFlag(state, state.RegisterY);
            CheckNegativeFlag(state, state.RegisterY);
        }
    }
}
