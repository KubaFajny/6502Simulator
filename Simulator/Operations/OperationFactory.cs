using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CPUSimulator.Operations;

namespace CPUSimulator
{
    /// <summary>
    /// The OperationFactory is a static class used solely to create a new instance of the <see cref="Operation"/> class.
    /// </summary>
    static class OperationFactory
    {
        private static Dictionary<string, Operation> operationTypes;

        static OperationFactory() {
            operationTypes = new Dictionary<string, Operation> {
                { "ADC", new OperationADC() },
                { "AND", new OperationAND() },
                { "ASL", new OperationASL() },
                { "BCC", new OperationBCC() },
                { "BCS", new OperationBCS() },
                { "BEQ", new OperationBEQ() },
                { "BIT", new OperationBIT() },
                { "BMI", new OperationBMI() },
                { "BNE", new OperationBNE() },
                { "BPL", new OperationBPL() },
                { "BRK", new OperationBRK() },
                { "BVC", new OperationBVC() },
                { "BVS", new OperationBVS() },
                { "CLC", new OperationCLC() },
                { "CLD", new OperationCLD() },
                { "CLI", new OperationCLI() },
                { "CLV", new OperationCLV() },
                { "CMP", new OperationCMP() },
                { "CPX", new OperationCPX() },
                { "CPY", new OperationCPY() },
                { "DEC", new OperationDEC() },
                { "DEX", new OperationDEX() },
                { "DEY", new OperationDEY() },
                { "EOR", new OperationEOR() },
                { "INC", new OperationINC() },
                { "INX", new OperationINX() },
                { "INY", new OperationINY() },
                { "JMP", new OperationJMP() },
                { "JSR", new OperationJSR() },
                { "LDA", new OperationLDA() },
                { "LDX", new OperationLDX() },
                { "LDY", new OperationLDY() },
                { "LSR", new OperationLSR() },
                { "NOP", new OperationNOP() },
                { "ORA", new OperationORA() },
                { "PHA", new OperationPHA() },
                { "PHP", new OperationPHP() },
                { "PLA", new OperationPLA() },
                { "PLP", new OperationPLP() },
                { "ROL", new OperationROL() },
                { "ROR", new OperationROR() },
                { "RTI", new OperationRTI() },
                { "RTS", new OperationRTS() },
                { "SBC", new OperationSBC() },
                { "SEC", new OperationSEC() },
                { "SED", new OperationSED() },
                { "SEI", new OperationSEI() },
                { "STA", new OperationSTA() },
                { "STX", new OperationSTX() },
                { "STY", new OperationSTY() },
                { "TAX", new OperationTAX() },
                { "TAY", new OperationTAY() },
                { "TSX", new OperationTSX() },
                { "TXA", new OperationTXA() },
                { "TXS", new OperationTXS() },
                { "TYA", new OperationTYA() }
            };
        }

        /// <summary>
        /// Creates a new Operation instance for the given instruction data.
        /// </summary>
        /// <param name="instruction">The <see cref="Instruction"/> instance holding required info about the instruction.</param>
        /// <param name="operand">The byte array containing the operand value.</param>
        /// <param name="address">The address at which the instruction is stored in the memory.</param>
        /// <returns>A new instance of the <see cref="Operation"/> class.</returns>
        public static Operation CreateOperation(Instruction instruction, byte[] operand, ushort address)
        {
            if (!operationTypes.TryGetValue(instruction.OpcodeName, out Operation operationType)) {
                throw new ArgumentException("Operation is not implemented for instruction opcode " + instruction.Opcode.ToString());
            }

            return operationType.Clone(instruction, operand, address);
        }
    }
}
