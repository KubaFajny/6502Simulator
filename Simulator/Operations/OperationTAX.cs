using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Operations
{
    /// <summary>
    /// Implements the Operation for the TAX instruction.
    /// </summary>
    class OperationTAX : Operation
    {
        public OperationTAX() {}

		protected OperationTAX(Instruction instruction, byte[] operand, ushort address) : base(instruction, operand, address) {}

		public override Operation Clone(Instruction instruction, byte[] operand, ushort address) {
			return new OperationTAX(instruction, operand, address);
		}

        public override void Execute(CPUState state, Bus bus)
        {
            state.RegisterX = state.Accumulator;
            CheckZeroFlag(state, state.RegisterX);
            CheckNegativeFlag(state, state.RegisterX);
        }
    }
}
