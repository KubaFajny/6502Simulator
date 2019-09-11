using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Operations
{
    /// <summary>
    /// Implements the Operation for the STY instruction.
    /// </summary>
    class OperationSTY : Operation
    {
        public OperationSTY() {}

		protected OperationSTY(Instruction instruction, byte[] operand, ushort address) : base(instruction, operand, address) {}

		public override Operation Clone(Instruction instruction, byte[] operand, ushort address) {
			return new OperationSTY(instruction, operand, address);
		}

        public override void Execute(CPUState state, Bus bus)
        {
            int effectiveAddress = CalculateEffectiveAddress(state, bus);
            bus.Write(effectiveAddress, state.RegisterY);
        }
    }
}
