﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator.Operations
{
    class OperationBRK : Operation
    {
        public OperationBRK(Instruction instruction, byte[] operand) : base(instruction, operand) { }

        public override void Execute(CPUState state, Bus bus)
        {
            state.PC = 0; // Doesn't really do this, but interrupting is not implemented yet.
        }
    }
}