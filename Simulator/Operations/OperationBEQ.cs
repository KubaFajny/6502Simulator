using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Operations
{
    /// <summary>
    /// Implements the Operation for the BEQ instruction.
    /// </summary>
    class OperationBEQ : Operation
    {
        public OperationBEQ() {}

		protected OperationBEQ(Instruction instruction, byte[] operand, ushort address) : base(instruction, operand, address) {}

		public override Operation Clone(Instruction instruction, byte[] operand, ushort address) {
			return new OperationBEQ(instruction, operand, address);
		}

        public override void Execute(CPUState state, Bus bus)
        {
            if (state.HasStatusFlag(StatusFlag.Zero))
                state.PC = (ushort) CalculateEffectiveAddress(state, bus);
        }
    }
}
