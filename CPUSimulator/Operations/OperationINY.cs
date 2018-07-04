using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator.Operations
{
    class OperationINY : Operation
    {
        public OperationINY(Instruction instruction, byte[] operand) : base(instruction, operand) { }

        public override void Execute(CPUState state, Bus bus)
        {
            state.registerY++;
            CheckZeroFlag(state, state.registerY);
            CheckNegativeFlag(state, state.registerY);
        }
    }
}
