using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator.Operations
{
    /// <summary>
    /// Implements the Operation for the CLD instruction.
    /// </summary>
    class OperationCLD : Operation
    {
        public OperationCLD() {}

		protected OperationCLD(Instruction instruction, byte[] operand, ushort address) : base(instruction, operand, address) {}

		public override Operation Clone(Instruction instruction, byte[] operand, ushort address) {
			return new OperationCLD(instruction, operand, address);
		}

        public override void Execute(CPUState state, Bus bus)
        {
            state.ChangeStatusFlag(StatusFlag.Decimal, false);
        }
    }
}
