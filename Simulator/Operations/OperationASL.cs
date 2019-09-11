using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator.Operations
{
    /// <summary>
    /// Implements the Operation for the ASL instruction.
    /// </summary>
    class OperationASL : Operation
    {
        public OperationASL() {}

		protected OperationASL(Instruction instruction, byte[] operand, ushort address) : base(instruction, operand, address) {}

		public override Operation Clone(Instruction instruction, byte[] operand, ushort address) {
			return new OperationASL(instruction, operand, address);
		}

        public override void Execute(CPUState state, Bus bus)
        {
            short result;
            if (Instruction.AddressMode != AddressMode.Accumulator)
            {
                int effectiveAddress = CalculateEffectiveAddress(state, bus);
                byte operandValue = bus.Read(effectiveAddress);
                result = (short)(operandValue << 1);
                bus.Write(effectiveAddress, (byte)result);
            }
            else
            {
                result = (short)(state.Accumulator << 1);
                state.Accumulator = (byte)result;
            }

            CheckNegativeFlag(state, (byte)result);
            CheckZeroFlag(state, result);
            state.ChangeStatusFlag(StatusFlag.Carry, result >> 8 == 1); // Set carry flag depending on whether the highest bit is 1 or not
        }
    }
}
