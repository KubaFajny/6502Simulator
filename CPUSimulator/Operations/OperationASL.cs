using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator.Operations
{
    class OperationASL : Operation
    {
        public OperationASL(Instruction instruction, byte[] operand) : base(instruction, operand) { }

        public override void Execute(CPUState state, Bus bus)
        {
            short result;
            if (instruction.GetAddressMode() != AddressMode.Accumulator)
            {
                int effectiveAddress = CalculateEffectiveAddress(state, bus);
                byte operandValue = bus.ReadFromMemory(effectiveAddress);
                result = (short)(operandValue << 1);
                bus.WriteToMemory(effectiveAddress, (byte)result);
            }
            else
            {
                result = (short)(state.accumulator << 1);
                state.accumulator = (byte)result;
            }

            CheckNegativeFlag(state, (byte)result);
            CheckZeroFlag(state, result);
            state.ChangeStatusFlag(StatusFlag.Carry, result >> 8 == 1);
        }
    }
}
