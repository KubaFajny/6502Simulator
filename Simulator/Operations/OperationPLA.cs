using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Operations
{
    /// <summary>
    /// Implements the Operation for the PLA instruction.
    /// </summary>
    class OperationPLA : Operation
    {
        public OperationPLA() {}

		protected OperationPLA(Instruction instruction, byte[] operand, ushort address) : base(instruction, operand, address) {}

		public override Operation Clone(Instruction instruction, byte[] operand, ushort address) {
			return new OperationPLA(instruction, operand, address);
		}

        public override void Execute(CPUState state, Bus bus)
        {
            state.Accumulator = bus.StackPop(state);
            CheckZeroFlag(state, state.Accumulator);
            CheckNegativeFlag(state, state.Accumulator);
        }
    }
}
