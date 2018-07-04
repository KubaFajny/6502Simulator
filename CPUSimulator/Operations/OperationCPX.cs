﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator.Operations
{
    class OperationCPX : Operation
    {
        public OperationCPX(Instruction instruction, byte[] operand) : base(instruction, operand) { }

        public override void Execute(CPUState state, Bus bus)
        {
            byte operandValue = GetOperandValue(state, bus);
            int result = state.registerX - operandValue;
            CheckZeroFlag(state, result);
            CheckNegativeFlag(state, result);
            CheckCarryFlag(state, state.registerX, operandValue);
        }
    }
}
