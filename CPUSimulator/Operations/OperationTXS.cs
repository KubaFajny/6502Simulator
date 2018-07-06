using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator.Operations
{
    class OperationTXS : Operation
    {
        public OperationTXS(Instruction instruction, byte[] operand) : base(instruction, operand) { }

        public override void Execute(CPUState state, Bus bus)
        {
            state.SP = state.registerX;
            CheckZeroFlag(state, state.SP);
            CheckNegativeFlag(state, state.SP);
        }
    }
}
