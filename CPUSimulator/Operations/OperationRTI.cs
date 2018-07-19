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
            state.status = bus.StackPop(state);
            byte[] returnAddress = new byte[2];
            returnAddress[0] = bus.StackPop(state); // Pop low byte
            returnAddress[1] = bus.StackPop(state); // Pop high byte
            state.PC = BitConverter.ToUInt16(returnAddress, 0);
        }
    }
}
