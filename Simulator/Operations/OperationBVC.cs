using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Operations
{
    /// <summary>
    /// Implements the Operation for the BVC instruction.
    /// </summary>
    class OperationBVC : Operation
    {
        public OperationBVC() {}

		protected OperationBVC(Instruction instruction, byte[] operand, ushort address) : base(instruction, operand, address) {}

		public override Operation Clone(Instruction instruction, byte[] operand, ushort address) {
			return new OperationBVC(instruction, operand, address);
		}

        public override void Execute(CPUState state, Bus bus)
        {
            if (!state.HasStatusFlag(StatusFlag.Overflow))
                state.PC = (ushort)CalculateEffectiveAddress(state, bus);
        }
    }
}
