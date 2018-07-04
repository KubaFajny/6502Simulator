using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator.Operations
{
    class OperationBEQ : Operation
    {
        public OperationBEQ(Instruction instruction, byte[] operand) : base(instruction, operand) { }

        public override void Execute(CPUState state, Bus bus)
        {
            int effectiveAddress = CalculateEffectiveAddress(state, bus);
            if (state.HasStatusFlag(StatusFlag.Zero))
                state.PC = (short)effectiveAddress;
        }
    }
}
