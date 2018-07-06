﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator.Operations
{
    class OperationTYA : Operation
    {
        public OperationTYA(Instruction instruction, byte[] operand) : base(instruction, operand) { }

        public override void Execute(CPUState state, Bus bus)
        {
            state.accumulator = state.registerY;
            CheckZeroFlag(state, state.accumulator);
            CheckNegativeFlag(state, state.accumulator);
        }
    }
}