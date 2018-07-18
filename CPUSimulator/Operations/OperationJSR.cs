﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator.Operations
{
    class OperationJSR : Operation
    {
        public OperationJSR(Instruction instruction, byte[] operand) : base(instruction, operand) { }

        public override void Execute(CPUState state, Bus bus)
        {
            int addressToPush = state.PC - 1;
            StackPush(state, bus, (byte)(addressToPush >> 8)); // Push high byte
            StackPush(state, bus, (byte)addressToPush); // Push low byte

            state.PC = (short) CalculateEffectiveAddress(state, bus);
        }
    }
}