using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator.Operations
{
    /// <summary>
    /// Implements the Operation for the ADC instruction.
    /// </summary>
    class OperationADC : Operation
    {
        public OperationADC() { }

        protected OperationADC(Instruction instruction, byte[] operand, ushort address) : base(instruction, operand, address) { }

        public override void Execute(CPUState state, Bus bus)
        {
            byte operandValue = GetOperandValue(state, bus);
            int result = state.Accumulator + operandValue + (state.HasStatusFlag(StatusFlag.Carry) ? 1 : 0);

            CheckOverflowFlag(state, state.Accumulator, operandValue, result);

            // Need to work here with integer result as we need to look at the 9th bit for carry
            state.ChangeStatusFlag(StatusFlag.Carry, (result & 0x100) != 0);

            state.Accumulator = (byte)result;
            CheckNegativeFlag(state, state.Accumulator);
            CheckZeroFlag(state, state.Accumulator);
        }

        public override Operation Clone(Instruction instruction, byte[] operand, ushort address) {
            return new OperationADC(instruction, operand, address);
        }
    }
}
