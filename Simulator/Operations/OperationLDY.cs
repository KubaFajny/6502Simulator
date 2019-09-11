using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Operations
{
    /// <summary>
    /// Implements the Operation for the LDY instruction.
    /// </summary>
    class OperationLDY : Operation
    {
        public OperationLDY() {}

		protected OperationLDY(Instruction instruction, byte[] operand, ushort address) : base(instruction, operand, address) {}

		public override Operation Clone(Instruction instruction, byte[] operand, ushort address) {
			return new OperationLDY(instruction, operand, address);
		}

        public override void Execute(CPUState state, Bus bus)
        {
            state.RegisterY = GetOperandValue(state, bus);
            CheckZeroFlag(state, state.RegisterY);
            CheckNegativeFlag(state, state.RegisterY);
        }
    }
}
