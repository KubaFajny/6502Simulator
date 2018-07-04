﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator.Operations
{
    class OperationSTX : Operation
    {
        public OperationSTX(Instruction instruction, byte[] operand) : base(instruction, operand) { }

        public override void Execute(CPUState state, Bus bus)
        {
            int effectiveAddress = CalculateEffectiveAddress(state, bus);
            bus.WriteToMemory(effectiveAddress, state.registerX);
        }
    }
}