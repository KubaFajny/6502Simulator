using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Operations
{
    /// <summary>
    /// Implements the Operation for the JMP instruction.
    /// </summary>
    class OperationJMP : Operation
    {
        public OperationJMP() {}

		protected OperationJMP(Instruction instruction, byte[] operand, ushort address) : base(instruction, operand, address) {}

		public override Operation Clone(Instruction instruction, byte[] operand, ushort address) {
			return new OperationJMP(instruction, operand, address);
		}

        public override void Execute(CPUState state, Bus bus)
        {
            state.PC = (ushort) CalculateEffectiveAddress(state, bus);
        }
    }
}
