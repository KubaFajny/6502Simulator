using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator.Operations
{
    /// <summary>
    /// Implements the Operation for the STA instruction.
    /// </summary>
    class OperationSTA : Operation
    {
        public OperationSTA() {}

		protected OperationSTA(Instruction instruction, byte[] operand, ushort address) : base(instruction, operand, address) {}

		public override Operation Clone(Instruction instruction, byte[] operand, ushort address) {
			return new OperationSTA(instruction, operand, address);
		}

        public override void Execute(CPUState state, Bus bus)
        {
            int effectiveAddress = CalculateEffectiveAddress(state, bus);
            bus.Write(effectiveAddress, state.Accumulator);
        }
    }
}
