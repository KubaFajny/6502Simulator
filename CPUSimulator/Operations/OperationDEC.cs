using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator.Operations
{
    class OperationDEC : Operation
    {
        public OperationDEC(Instruction instruction, byte[] operand) : base(instruction, operand) { }

        public override void Execute(CPUState state, Bus bus)
        {
            int effectiveAddress = CalculateEffectiveAddress(state, bus);
            byte decOperand = bus.ReadFromMemory(effectiveAddress);
            --decOperand;
            bus.WriteToMemory(effectiveAddress, decOperand);
            CheckZeroFlag(state, decOperand);
            CheckNegativeFlag(state, decOperand);
        }
    }
}
