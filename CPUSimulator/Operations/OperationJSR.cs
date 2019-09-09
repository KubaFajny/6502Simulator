using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator.Operations
{
    /// <summary>
    /// Implements the Operation for the JSR instruction.
    /// </summary>
    class OperationJSR : Operation
    {
        public OperationJSR() {}

		protected OperationJSR(Instruction instruction, byte[] operand, ushort address) : base(instruction, operand, address) {}

		public override Operation Clone(Instruction instruction, byte[] operand, ushort address) {
			return new OperationJSR(instruction, operand, address);
		}

        public override void Execute(CPUState state, Bus bus)
        {
            int addressToPush = state.PC - 1;
            bus.StackPush(state, (byte)(addressToPush >> 8)); // Push high byte
            bus.StackPush(state, (byte)addressToPush); // Push low byte

            state.PC = (ushort) CalculateEffectiveAddress(state, bus);
        }
    }
}
