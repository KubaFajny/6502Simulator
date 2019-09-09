using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator.Operations
{
    /// <summary>
    /// Implements the Operation for the RTI instruction.
    /// </summary>
    class OperationRTI : Operation
    {
        public OperationRTI() {}

		protected OperationRTI(Instruction instruction, byte[] operand, ushort address) : base(instruction, operand, address) {}

		public override Operation Clone(Instruction instruction, byte[] operand, ushort address) {
			return new OperationRTI(instruction, operand, address);
		}

        public override void Execute(CPUState state, Bus bus)
        {
            state.Status = bus.StackPop(state);
            byte[] returnAddress = new byte[2];
            returnAddress[0] = bus.StackPop(state); // Pop low byte
            returnAddress[1] = bus.StackPop(state); // Pop high byte
            state.PC = BitConverter.ToUInt16(returnAddress, 0);
        }
    }
}
