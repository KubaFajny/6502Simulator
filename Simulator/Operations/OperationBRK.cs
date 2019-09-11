using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Operations
{
    /// <summary>
    /// Implements the Operation for the BRK instruction.
    /// </summary>
    class OperationBRK : Operation
    {
        public OperationBRK() {}

		protected OperationBRK(Instruction instruction, byte[] operand, ushort address) : base(instruction, operand, address) {}

		public override Operation Clone(Instruction instruction, byte[] operand, ushort address) {
			return new OperationBRK(instruction, operand, address);
		}

        public override void Execute(CPUState state, Bus bus)
        {
            state.IrqInvoked = true;
        }
    }
}
