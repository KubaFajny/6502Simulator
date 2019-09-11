using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Operations
{
    /// <summary>
    /// Implements the Operation for the CPX instruction.
    /// </summary>
    class OperationCPX : Operation
    {
        public OperationCPX() {}

		protected OperationCPX(Instruction instruction, byte[] operand, ushort address) : base(instruction, operand, address) {}

		public override Operation Clone(Instruction instruction, byte[] operand, ushort address) {
			return new OperationCPX(instruction, operand, address);
		}

        public override void Execute(CPUState state, Bus bus)
        {
            byte operandValue = GetOperandValue(state, bus);
            int result = state.RegisterX - operandValue;
            CheckZeroFlag(state, result);
            CheckNegativeFlag(state, result);
            CheckCarryFlag(state, state.RegisterX, operandValue);
        }
    }
}
