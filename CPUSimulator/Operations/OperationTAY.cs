using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator.Operations
{
    class OperationTAY : Operation
    {
        public OperationTAY(Instruction instruction, byte[] operand) : base(instruction, operand) { }

        public override void Execute(CPUState state, Bus bus)
        {
            state.registerY = state.accumulator;
            CheckZeroFlag(state, state.registerY);
            CheckNegativeFlag(state, state.registerY);
        }
    }
}
