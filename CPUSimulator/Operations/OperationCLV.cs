using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator.Operations
{
    /// <summary>
    /// Implements the Operation for the CLV instruction.
    /// </summary>
    class OperationCLV : Operation
    {
        public OperationCLV() {}

		protected OperationCLV(Instruction instruction, byte[] operand, ushort address) : base(instruction, operand, address) {}

		public override Operation Clone(Instruction instruction, byte[] operand, ushort address) {
			return new OperationCLV(instruction, operand, address);
		}

        public override void Execute(CPUState state, Bus bus)
        {
            state.ChangeStatusFlag(StatusFlag.Overflow, false);
        }
    }
}
