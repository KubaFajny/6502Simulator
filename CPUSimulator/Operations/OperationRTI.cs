using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator.Operations
{
    class OperationRTI : Operation
    {
        public OperationRTI(Instruction instruction, byte[] operand) : base(instruction, operand) { }

        public override void Execute(CPUState state, Bus bus)
        {
            state.status = StackPop(state, bus);
            byte[] returnAddress = new byte[2];
            returnAddress[0] = StackPop(state, bus); // Pop low byte
            returnAddress[1] = StackPop(state, bus); // Pop high byte
            state.PC = BitConverter.ToInt16(returnAddress, 0);
        }
    }
}
