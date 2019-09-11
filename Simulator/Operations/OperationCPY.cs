using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator.Operations
{
    /// <summary>
    /// Implements the Operation for the CPY instruction.
    /// </summary>
    class OperationCPY : Operation
    {
        public OperationCPY() {}

		protected OperationCPY(Instruction instruction, byte[] operand, ushort address) : base(instruction, operand, address) {}

		public override Operation Clone(Instruction instruction, byte[] operand, ushort address) {
			return new OperationCPY(instruction, operand, address);
		}

        public override void Execute(CPUState state, Bus bus)
        {
            byte operandValue = GetOperandValue(state, bus);
            int result = state.RegisterY - operandValue;
            CheckZeroFlag(state, result);
            CheckNegativeFlag(state, result);
            CheckCarryFlag(state, state.RegisterY, operandValue);
        }
    }
}
