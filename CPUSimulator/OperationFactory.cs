using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator
{
    static class OperationFactory
    {
        public static Operation CreateOperation(Instruction instruction, byte[] operand)
        {
            Type operationType = Type.GetType("CPUSimulator.Operations.Operation" + instruction.GetOpcodeName());
            if (operationType == null)
                throw new ArgumentException("Operation is not implemented for instruction opcode " + instruction.GetOpcode().ToString());

            return (Operation) Activator.CreateInstance(operationType, instruction, operand);
        }
    }
}
