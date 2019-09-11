using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator.Operations
{
    /// <summary>
    /// Implements the Operation for the CLC instruction.
    /// </summary>
    class OperationCLC : Operation
    {
        public OperationCLC() {}

		protected OperationCLC(Instruction instruction, byte[] operand, ushort address) : base(instruction, operand, address) {}

		public override Operation Clone(Instruction instruction, byte[] operand, ushort address) {
			return new OperationCLC(instruction, operand, address);
		}

        public override void Execute(CPUState state, Bus bus)
        {
            state.ChangeStatusFlag(StatusFlag.Carry, false);
        }
    }
}
