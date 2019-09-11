﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Operations
{
    /// <summary>
    /// Implements the Operation for the SEI instruction.
    /// </summary>
    class OperationSEI : Operation
    {
        public OperationSEI() {}

		protected OperationSEI(Instruction instruction, byte[] operand, ushort address) : base(instruction, operand, address) {}

		public override Operation Clone(Instruction instruction, byte[] operand, ushort address) {
			return new OperationSEI(instruction, operand, address);
		}

        public override void Execute(CPUState state, Bus bus)
        {
            state.ChangeStatusFlag(StatusFlag.InterruptDisable, true);
        }
    }
}
