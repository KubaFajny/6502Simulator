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
            int lowByteAddress = CalculateEffectiveAddress(state, bus);
            byte[] newProgramAddress = bus.ReadFromMemory(lowByteAddress, 2);
            state.PC = BitConverter.ToInt16(newProgramAddress, 0);
        }
    }
}
