using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator.Operations
{
    class OperationJSR : Operation
    {
        public OperationJSR(Instruction instruction, byte[] operand) : base(instruction, operand) { }

        public override void Execute(CPUState state, Bus bus)
        {
            int addressToPush = state.PC - 1;
            bus.StackPush(state, (byte)(addressToPush >> 8)); // Push high byte
            bus.StackPush(state, (byte)addressToPush); // Push low byte

            state.PC = (ushort) CalculateEffectiveAddress(state, bus);
        }
    }
}
