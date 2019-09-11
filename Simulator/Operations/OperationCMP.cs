using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator.Operations
{
    /// <summary>
    /// Implements the Operation for the CMP instruction.
    /// </summary>
    class OperationCMP : Operation
    {
        public OperationCMP() {}

		protected OperationCMP(Instruction instruction, byte[] operand, ushort address) : base(instruction, operand, address) {}

		public override Operation Clone(Instruction instruction, byte[] operand, ushort address) {
			return new OperationCMP(instruction, operand, address);
		}

        public override void Execute(CPUState state, Bus bus)
        { 
            byte operandValue = GetOperandValue(state, bus);
            int result = state.Accumulator - operandValue;
            CheckZeroFlag(state, result);
            CheckNegativeFlag(state, result);
            CheckCarryFlag(state, state.Accumulator, operandValue);
        }
    }
}
