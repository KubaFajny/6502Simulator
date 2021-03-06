﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Operations
{
    /// <summary>
    /// Implements the Operation for the BNE instruction.
    /// </summary>
    class OperationBNE : Operation
    {
        public OperationBNE() {}

		protected OperationBNE(Instruction instruction, byte[] operand, ushort address) : base(instruction, operand, address) {}

		public override Operation Clone(Instruction instruction, byte[] operand, ushort address) {
			return new OperationBNE(instruction, operand, address);
		}

        public override void Execute(CPUState state, Bus bus)
        {
            if (!state.HasStatusFlag(StatusFlag.Zero))
                state.PC = (ushort) CalculateEffectiveAddress(state, bus);
        }
    }
}
