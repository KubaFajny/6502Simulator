﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator.Operations
{
    class OperationINX : Operation
    {
        public OperationINX(Instruction instruction, byte[] operand) : base(instruction, operand) { }

        public override void Execute(CPUState state, Bus bus)
        {
            state.registerX++;
            CheckZeroFlag(state, state.registerX);
            CheckNegativeFlag(state, state.registerX);
        }
    }
}