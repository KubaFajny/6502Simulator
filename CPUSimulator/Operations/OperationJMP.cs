using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator.Operations
{
    class OperationJMP : Operation
    {
        public OperationJMP(Instruction instruction, byte[] operand) : base(instruction, operand) { }

        public override void Execute(CPUState state, Bus bus)
        {
            state.PC = (ushort) CalculateEffectiveAddress(state, bus);
        }
    }
}
