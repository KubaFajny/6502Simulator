using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Operations
{
    /// <summary>
    /// Implements the Operation for the BCS instruction.
    /// </summary>
    class OperationBCS : Operation
    {
        public OperationBCS() {}

		protected OperationBCS(Instruction instruction, byte[] operand, ushort address) : base(instruction, operand, address) {}

		public override Operation Clone(Instruction instruction, byte[] operand, ushort address) {
			return new OperationBCS(instruction, operand, address);
		}

        public override void Execute(CPUState state, Bus bus)
        {
            if (state.HasStatusFlag(StatusFlag.Carry))
                state.PC = (ushort) CalculateEffectiveAddress(state, bus);
        }
    }
}
