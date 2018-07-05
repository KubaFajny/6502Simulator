using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator.Operations
{
    class OperationLSR : Operation
    {
        public OperationLSR(Instruction instruction, byte[] operand) : base(instruction, operand) { }

        public override void Execute(CPUState state, Bus bus)
        {
            byte result;
            if (instruction.GetAddressMode() != AddressMode.Accumulator)
            {
                int effectiveAddress = CalculateEffectiveAddress(state, bus);
                byte operandValue = bus.ReadFromMemory(effectiveAddress);
                state.ChangeStatusFlag(StatusFlag.Carry, (operandValue & 1) == 1);
                result = (byte)(operandValue >> 1);
                bus.WriteToMemory(effectiveAddress, result);
            }
            else
            {
                state.ChangeStatusFlag(StatusFlag.Carry, (state.accumulator & 1) == 1);
                result = (byte)(state.accumulator >> 1);
                state.accumulator = result;
            }

            CheckZeroFlag(state, result);
        }
    }
}
