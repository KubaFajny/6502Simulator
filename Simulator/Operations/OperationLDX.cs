using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Operations
{
    /// <summary>
    /// Implements the Operation for the LDX instruction.
    /// </summary>
    class OperationLDX : Operation
    {
        public OperationLDX() {}

		protected OperationLDX(Instruction instruction, byte[] operand, ushort address) : base(instruction, operand, address) {}

		public override Operation Clone(Instruction instruction, byte[] operand, ushort address) {
			return new OperationLDX(instruction, operand, address);
		}

        public override void Execute(CPUState state, Bus bus)
        {
            state.RegisterX = GetOperandValue(state, bus);
            CheckZeroFlag(state, state.RegisterX);
            CheckNegativeFlag(state, state.RegisterX);
        }
    }
}
