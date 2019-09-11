using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator.Operations
{
    /// <summary>
    /// Implements the Operation for the INC instruction.
    /// </summary>
    class OperationINC : Operation
    {
        public OperationINC() {}

		protected OperationINC(Instruction instruction, byte[] operand, ushort address) : base(instruction, operand, address) {}

		public override Operation Clone(Instruction instruction, byte[] operand, ushort address) {
			return new OperationINC(instruction, operand, address);
		}

        public override void Execute(CPUState state, Bus bus)
        {
            int effectiveAddress = CalculateEffectiveAddress(state, bus);
            byte decOperand = bus.Read(effectiveAddress);
            ++decOperand;
            bus.Write(effectiveAddress, decOperand);
            CheckZeroFlag(state, decOperand);
            CheckNegativeFlag(state, decOperand);
        }
    }
}
