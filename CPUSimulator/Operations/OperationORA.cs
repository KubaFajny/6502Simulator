using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator.Operations
{
    class OperationORA : Operation
    {
        public OperationORA(Instruction instruction, byte[] operand) : base(instruction, operand) { }

        public override void Execute(CPUState state, Bus bus)
        {
            byte operandValue = GetOperandValue(state, bus);
            int result = state.accumulator | operandValue;
            CheckNegativeFlag(state, result);
            CheckZeroFlag(state, result);
            state.accumulator = (byte) result;
        }
    }
}
