using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Operations
{
    /// <summary>
    /// Implements the Operation for the BMI instruction.
    /// </summary>
    class OperationBMI : Operation
    {
        public OperationBMI() {}

		protected OperationBMI(Instruction instruction, byte[] operand, ushort address) : base(instruction, operand, address) {}

		public override Operation Clone(Instruction instruction, byte[] operand, ushort address) {
			return new OperationBMI(instruction, operand, address);
		}

        public override void Execute(CPUState state, Bus bus)
        {
            if (state.HasStatusFlag(StatusFlag.Negative))
                state.PC = (ushort) CalculateEffectiveAddress(state, bus);
        }
    }
}
