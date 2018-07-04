﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator.Operations
{
    class OperationCLV : Operation
    {
        public OperationCLV(Instruction instruction, byte[] operand) : base(instruction, operand) { }

        public override void Execute(CPUState state, Bus bus)
        {
            state.ChangeStatusFlag(StatusFlag.Overflow, false);
        }
    }
}