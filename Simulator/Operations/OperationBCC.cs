using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator.Operations
{
    /// <summary>
    /// Implements the Operation for the BCC instruction.
    /// </summary>
    class OperationBCC : Operation
    {
        public OperationBCC() {}

		protected OperationBCC(Instruction instruction, byte[] operand, ushort address) : base(instruction, operand, address) {}

		public override Operation Clone(Instruction instruction, byte[] operand, ushort address) {
			return new OperationBCC(instruction, operand, address);
		}

        public override void Execute(CPUState state, Bus bus)
        {
            if (!state.HasStatusFlag(StatusFlag.Carry))
                state.PC = (ushort)CalculateEffectiveAddress(state, bus);
        }
    }
}
