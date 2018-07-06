using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator.Operations
{
    class OperationBIT : Operation
    {
        public OperationBIT(Instruction instruction, byte[] operand) : base(instruction, operand) { }

        public override void Execute(CPUState state, Bus bus)
        {
            byte operandValue = GetOperandValue(state, bus);
            byte result = (byte) (state.accumulator & operandValue);

            // Bits 7 and 6 of operand are transfered to bit 7 and 6 of status register (Negative, Overflow)
            state.ChangeStatusFlag(StatusFlag.Negative, (result & 0x80) == 1);
            state.ChangeStatusFlag(StatusFlag.Overflow, (result & 0x40) == 1);

            // The zeroflag is set to the result of operand AND accumulator
            CheckZeroFlag(state, result);
        }
    }
}
