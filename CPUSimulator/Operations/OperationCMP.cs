using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator.Operations
{
    class OperationCMP : Operation
    {
        public OperationCMP(Instruction instruction, byte[] operand) : base(instruction, operand) { }

        public override void Execute(CPUState state, Bus bus)
        { 
            byte operandValue = GetOperandValue(state, bus);
            int result = state.accumulator - operandValue;
            CheckZeroFlag(state, result);
            CheckNegativeFlag(state, result);
            CheckCarryFlag(state, state.accumulator, operandValue);
        }
    }
}
