using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator.Operations
{
    class OperationSBC : Operation
    {
        public OperationSBC(Instruction instruction, byte[] operand) : base(instruction, operand) { }

        public override void Execute(CPUState state, Bus bus)
        {
            byte operandValue = GetOperandValue(state, bus);
            int result = state.accumulator - operandValue - (state.HasStatusFlag(StatusFlag.Carry) ? 1 : 0);
            CheckNegativeFlag(state, result);
            CheckZeroFlag(state, result);
            state.ChangeStatusFlag(StatusFlag.Carry, (result & 0x100) != 0);

            // TODO: learn how this works: http://www.righto.com/2012/12/the-6502-overflow-flag-explained.html
            CheckOverflowFlag(state, state.accumulator, operandValue, result);

            state.accumulator = (byte)result;
        }
    }
}
