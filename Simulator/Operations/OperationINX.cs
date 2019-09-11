using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Operations
{
    /// <summary>
    /// Implements the Operation for the INX instruction.
    /// </summary>
    class OperationINX : Operation
    {
        public OperationINX() {}

		protected OperationINX(Instruction instruction, byte[] operand, ushort address) : base(instruction, operand, address) {}

		public override Operation Clone(Instruction instruction, byte[] operand, ushort address) {
			return new OperationINX(instruction, operand, address);
		}

        public override void Execute(CPUState state, Bus bus)
        {
            state.RegisterX++;
            CheckZeroFlag(state, state.RegisterX);
            CheckNegativeFlag(state, state.RegisterX);
        }
    }
}
