using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Operations
{
    /// <summary>
    /// Implements the Operation for the RTS instruction.
    /// </summary>
    class OperationRTS : Operation
    {
        public OperationRTS() {}

		protected OperationRTS(Instruction instruction, byte[] operand, ushort address) : base(instruction, operand, address) {}

		public override Operation Clone(Instruction instruction, byte[] operand, ushort address) {
			return new OperationRTS(instruction, operand, address);
		}

        public override void Execute(CPUState state, Bus bus)
        {
            byte[] returnAddress = new byte[2];
            returnAddress[0] = bus.StackPop(state); // Pop low byte
            returnAddress[1] = bus.StackPop(state); // Pop high byte
            state.PC = (ushort) (GetUInt16FromBytes(returnAddress) + 1);
        }
    }
}
