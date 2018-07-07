using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator
{
    public enum Opcode
    {
        BRK      = 0x00,
        LDY_IMM  = 0xA0,
        LDY_ZP   = 0xA4,
        LDY_ABS  = 0xAC,
        LDY_ZPX  = 0xB4,
        LDY_ABSX = 0xBC,
        LDX_IMM  = 0xA2,
        LDX_ZP   = 0xA6,
        LDX_ABS  = 0xAE,
        LDX_ZPY  = 0xB6,
        LDX_ABSY = 0xBE,
        LDA_INDX = 0xA1,
        LDA_ZP   = 0xA5,
        LDA_IMM  = 0xA9,
        LDA_ABS  = 0xAD,
        LDA_INDY = 0xB1,
        LDA_ZPX  = 0xB5,
        LDA_ABSY = 0xB9,
        LDA_ABSX = 0xBD,
        STA_INDX = 0x81,
        STA_ZP   = 0x85,
        STA_ABS  = 0x8D,
        STA_INDY = 0x91,
        STA_ZPX  = 0x95,
        STA_ABSX = 0x9D,
        ADC_IMM  = 0x69,
        ADC_ZP   = 0x65,
        ADC_ZPX  = 0x75,
        ADC_ABS  = 0x6D,
        ADC_ABSX = 0x7D,
        ADC_ABSY = 0x79,
        ADC_INDX = 0x61,
        ADC_INDY = 0x71,
        CMP_IMM  = 0xC9,
        CMP_ZP   = 0xC5,
        CMP_ZPX  = 0xD5,
        CMP_ABS  = 0xCD,
        CMP_ABSX = 0xDD,
        CMP_ABSY = 0xD9,
        CMP_INDX = 0xC1,
        CMP_INDY = 0xD1,
        CPX_IMM  = 0xE0,
        CPX_ZP   = 0xE4,
        CPX_ABS  = 0xEC,
        CPY_IMM  = 0xC0,
        CPY_ZP   = 0xC4,
        CPY_ABS  = 0xCC,
        AND_IMM  = 0x29,
        AND_ZP   = 0x25,
        AND_ZPX  = 0x35,
        AND_ABS  = 0x2D,
        AND_ABSX = 0x3D,
        AND_ABSY = 0x39,
        AND_INDX = 0x21,
        AND_INDY = 0x31,
        ASL_ACC  = 0x0A,
        ASL_ZP   = 0x06,
        ASL_ZPX  = 0x16,
        ASL_ABS  = 0x0E,
        ASL_ABSX = 0x1E,
        BNE      = 0xD0,
        BMI      = 0x30,
        BCC      = 0x90,
        BCS      = 0xB0,
        BEQ      = 0xF0,
        BPL      = 0x10,
        BVC      = 0x50,
        BVS      = 0x70,
        CLC      = 0x18,
        CLD      = 0xD8,
        CLI      = 0x58,
        CLV      = 0xB8,
        DEC_ZP   = 0xC6,
        DEC_ZPX  = 0xD6,
        DEC_ABS  = 0xCE,
        DEC_ABSX = 0xDE,
        DEX      = 0xCA,
        DEY      = 0x88,
        INC_ZP   = 0xE6,
        INC_ZPX  = 0xF6,
        INC_ABS  = 0xEE,
        INC_ABSX = 0xFE,
        INX      = 0xE8,
        INY      = 0xC8,
        EOR_IMM  = 0x49,
        EOR_ZP   = 0x45,
        EOR_ZPX  = 0x55,
        EOR_ABS  = 0x4D,
        EOR_ABSX = 0x5D,
        EOR_ABSY = 0x59,
        EOR_INDX = 0x41,
        EOR_INDY = 0x51,
        JMP_ABS  = 0x4C,
        JMP_IND  = 0x6C,
        JSR      = 0x20,
        LSR_ACC  = 0x4A,
        LSR_ZP   = 0x46,
        LSR_ZPX  = 0x56,
        LSR_ABS  = 0x4E,
        LSR_ABSX = 0x5E,
        NOP      = 0xEA,
        ORA_IMM  = 0x09,
        ORA_ZP   = 0x05,
        ORA_ZPX  = 0x15,
        ORA_ABS  = 0x0D,
        ORA_ABSX = 0x1D,
        ORA_ABSY = 0x19,
        ORA_INDX = 0x01,
        ORA_INDY = 0x11,
        PHA      = 0x48,
        PHP      = 0x08,
        PLA      = 0x68,
        PLP      = 0x28,
        ROL_ACC  = 0x2A,
        ROL_ZP   = 0x26,
        ROL_ZPX  = 0x36,
        ROL_ABS  = 0x2E,
        ROL_ABSX = 0x3E,
        ROR_ACC  = 0x6A,
        ROR_ZP   = 0x66,
        ROR_ZPX  = 0x76,
        ROR_ABS  = 0x6E,
        ROR_ABSX = 0x7E,
        RTI      = 0x40,
        RTS      = 0x60,
        SBC_IMM  = 0xE9,
        SBC_ZP   = 0xE5,
        SBC_ZPX  = 0xF5,
        SBC_ABS  = 0xED,
        SBC_ABSX = 0xFD,
        SBC_ABSY = 0xF9,
        SBC_INDX = 0xE1,
        SBC_INDY = 0xF1,
        SEC      = 0x38,
        SED      = 0xF8,
        SEI      = 0x78,
        STX_ZP   = 0x86,
        STX_ZPY  = 0x96,
        STX_ABS  = 0x8E,
        STY_ZP   = 0x84,
        STY_ZPX  = 0x94,
        STY_ABS  = 0x8C,
        TAX      = 0xAA,
        TAY      = 0xA8,
        TSX      = 0xBA,
        TXA      = 0x8A,
        TXS      = 0x9A,
        TYA      = 0x98,
        BIT_ZP   = 0x24,
        BIT_ABS  = 0x2C
    }

    static class InstructionSet
    {
        private static Dictionary<Opcode, Instruction> instructions;

        static InstructionSet()
        {
            instructions = new Dictionary<Opcode, Instruction>
            {
                // Load Index Y with Memory
                { Opcode.LDY_IMM, new Instruction(Opcode.LDY_IMM, AddressMode.Immediate, "LDY", 2) },
                { Opcode.LDY_ZP, new Instruction(Opcode.LDY_ZP, AddressMode.ZeroPage, "LDY", 3) },
                { Opcode.LDY_ABS, new Instruction(Opcode.LDY_ABS, AddressMode.Absolute, "LDY", 4) },
                { Opcode.LDY_ZPX, new Instruction(Opcode.LDY_ZPX, AddressMode.ZeroPageX, "LDY", 4) },
                { Opcode.LDY_ABSX, new Instruction(Opcode.LDY_ABSX, AddressMode.AbsoluteX, "LDY", 4) },

                // Load Index X with Memory
                { Opcode.LDX_IMM, new Instruction(Opcode.LDX_IMM, AddressMode.Immediate, "LDX", 2) },
                { Opcode.LDX_ZP, new Instruction(Opcode.LDX_ZP, AddressMode.ZeroPage, "LDX", 3) },
                { Opcode.LDX_ABS, new Instruction(Opcode.LDX_ABS, AddressMode.Absolute, "LDX", 4) },
                { Opcode.LDX_ZPY, new Instruction(Opcode.LDX_ZPY, AddressMode.ZeroPageY, "LDX", 4) },
                { Opcode.LDX_ABSY, new Instruction(Opcode.LDX_ABSY, AddressMode.AbsoluteY, "LDX", 4) },

                // Load Accumulator with Memory
                { Opcode.LDA_INDX, new Instruction(Opcode.LDA_INDX, AddressMode.IndirectX, "LDA", 6) },
                { Opcode.LDA_ZP, new Instruction(Opcode.LDA_ZP, AddressMode.ZeroPage, "LDA", 3) },
                { Opcode.LDA_IMM, new Instruction(Opcode.LDA_IMM, AddressMode.Immediate, "LDA", 2) },
                { Opcode.LDA_ABS, new Instruction(Opcode.LDA_ABS, AddressMode.Absolute, "LDA", 4) },
                { Opcode.LDA_INDY, new Instruction(Opcode.LDA_INDY, AddressMode.IndirectY, "LDA", 5) },
                { Opcode.LDA_ZPX, new Instruction(Opcode.LDA_ZPX, AddressMode.ZeroPageX, "LDA", 4) },
                { Opcode.LDA_ABSY, new Instruction(Opcode.LDA_ABSY, AddressMode.AbsoluteY, "LDA", 4) },
                { Opcode.LDA_ABSX, new Instruction(Opcode.LDA_ABSX, AddressMode.AbsoluteX, "LDA", 4) },

                // Store Accumulator in Memory
                { Opcode.STA_INDX, new Instruction(Opcode.STA_INDX, AddressMode.IndirectX, "STA", 6) },
                { Opcode.STA_ZP, new Instruction(Opcode.STA_ZP, AddressMode.ZeroPage, "STA", 3) },
                { Opcode.STA_ABS, new Instruction(Opcode.STA_ABS, AddressMode.Absolute, "STA", 4) },
                { Opcode.STA_INDY, new Instruction(Opcode.STA_INDY, AddressMode.IndirectY, "STA", 5) },
                { Opcode.STA_ZPX, new Instruction(Opcode.STA_ZPX, AddressMode.ZeroPageX, "STA", 4) },
                { Opcode.STA_ABSX, new Instruction(Opcode.STA_ABSX, AddressMode.AbsoluteX, "STA", 4) },

                // Store Index X in Memory
                { Opcode.STX_ZP, new Instruction(Opcode.STX_ZP, AddressMode.ZeroPage, "STX", 3) },
                { Opcode.STX_ZPY, new Instruction(Opcode.STX_ZPY, AddressMode.ZeroPageY, "STX", 4) },
                { Opcode.STX_ABS, new Instruction(Opcode.STX_ABS, AddressMode.Absolute, "STX", 4) },

                // Store Index Y in Memory
                { Opcode.STY_ZP, new Instruction(Opcode.STY_ZP, AddressMode.ZeroPage, "STY", 3) },
                { Opcode.STY_ZPX, new Instruction(Opcode.STY_ZPX, AddressMode.ZeroPageY, "STY", 4) },
                { Opcode.STY_ABS, new Instruction(Opcode.STY_ABS, AddressMode.Absolute, "STY", 4) },

                // Add Memory to Accumulator with Carry
                { Opcode.ADC_IMM, new Instruction(Opcode.ADC_IMM, AddressMode.Immediate, "ADC", 2) },
                { Opcode.ADC_ZP, new Instruction(Opcode.ADC_ZP, AddressMode.ZeroPage, "ADC", 3) },
                { Opcode.ADC_ZPX, new Instruction(Opcode.ADC_ZPX, AddressMode.ZeroPageX, "ADC", 4) },
                { Opcode.ADC_ABS, new Instruction(Opcode.ADC_ABS, AddressMode.Absolute, "ADC", 4) },
                { Opcode.ADC_ABSX, new Instruction(Opcode.ADC_ABSX, AddressMode.AbsoluteX, "ADC", 4) },
                { Opcode.ADC_ABSY, new Instruction(Opcode.ADC_ABSY, AddressMode.AbsoluteY, "ADC", 4) },
                { Opcode.ADC_INDX, new Instruction(Opcode.ADC_INDX, AddressMode.IndirectX, "ADC", 6) },
                { Opcode.ADC_INDY, new Instruction(Opcode.ADC_INDY, AddressMode.IndirectY, "ADC", 5) },

                // Subtract Memory from Accumulator with Borrow
                { Opcode.SBC_IMM, new Instruction(Opcode.SBC_IMM, AddressMode.Immediate, "SBC", 2) },
                { Opcode.SBC_ZP, new Instruction(Opcode.SBC_ZP, AddressMode.ZeroPage, "SBC", 3) },
                { Opcode.SBC_ZPX, new Instruction(Opcode.SBC_ZPX, AddressMode.ZeroPageX, "SBC", 4) },
                { Opcode.SBC_ABS, new Instruction(Opcode.SBC_ABS, AddressMode.Absolute, "SBC", 4) },
                { Opcode.SBC_ABSX, new Instruction(Opcode.SBC_ABSX, AddressMode.AbsoluteX, "SBC", 4) },
                { Opcode.SBC_ABSY, new Instruction(Opcode.SBC_ABSY, AddressMode.AbsoluteY, "SBC", 4) },
                { Opcode.SBC_INDX, new Instruction(Opcode.SBC_INDX, AddressMode.IndirectX, "SBC", 6) },
                { Opcode.SBC_INDY, new Instruction(Opcode.SBC_INDY, AddressMode.IndirectY, "SBC", 5) },

                // Compare Memory with Accumulator
                { Opcode.CMP_IMM, new Instruction(Opcode.CMP_IMM, AddressMode.Immediate, "CMP", 2) },
                { Opcode.CMP_ZP, new Instruction(Opcode.CMP_ZP, AddressMode.ZeroPage, "CMP", 3) },
                { Opcode.CMP_ZPX, new Instruction(Opcode.CMP_ZPX, AddressMode.ZeroPageX, "CMP", 4) },
                { Opcode.CMP_ABS, new Instruction(Opcode.CMP_ABS, AddressMode.Absolute, "CMP", 4) },
                { Opcode.CMP_ABSX, new Instruction(Opcode.CMP_ABSX, AddressMode.AbsoluteX, "CMP", 4) },
                { Opcode.CMP_ABSY, new Instruction(Opcode.CMP_ABSY, AddressMode.AbsoluteY, "CMP", 4) },
                { Opcode.CMP_INDX, new Instruction(Opcode.CMP_INDX, AddressMode.IndirectX, "CMP", 6) },
                { Opcode.CMP_INDY, new Instruction(Opcode.CMP_INDY, AddressMode.IndirectY, "CMP", 5) },

                // Compare Memory and Index X
                { Opcode.CPX_IMM, new Instruction(Opcode.CPX_IMM, AddressMode.Immediate, "CPX", 2) },
                { Opcode.CPX_ZP, new Instruction(Opcode.CPX_ZP, AddressMode.ZeroPage, "CPX", 3) },
                { Opcode.CPX_ABS, new Instruction(Opcode.CPX_ABS, AddressMode.Absolute, "CPX", 4) },

                // Compare Memory and Index Y
                { Opcode.CPY_IMM, new Instruction(Opcode.CPY_IMM, AddressMode.Immediate, "CPY", 2) },
                { Opcode.CPY_ZP, new Instruction(Opcode.CPY_ZP, AddressMode.ZeroPage, "CPY", 3) },
                { Opcode.CPY_ABS, new Instruction(Opcode.CPY_ABS, AddressMode.Absolute, "CPY", 4) },

                // AND Memory with Accumulator
                { Opcode.AND_IMM, new Instruction(Opcode.AND_IMM, AddressMode.Immediate, "AND", 2) },
                { Opcode.AND_ZP, new Instruction(Opcode.AND_ZP, AddressMode.ZeroPage, "AND", 3) },
                { Opcode.AND_ZPX, new Instruction(Opcode.AND_ZPX, AddressMode.ZeroPageX, "AND", 4) },
                { Opcode.AND_ABS, new Instruction(Opcode.AND_ABS, AddressMode.Absolute, "AND", 4) },
                { Opcode.AND_ABSX, new Instruction(Opcode.AND_ABSX, AddressMode.AbsoluteX, "AND", 4) },
                { Opcode.AND_ABSY, new Instruction(Opcode.AND_ABSY, AddressMode.AbsoluteY, "AND", 4) },
                { Opcode.AND_INDX, new Instruction(Opcode.AND_INDX, AddressMode.IndirectX, "AND", 6) },
                { Opcode.AND_INDY, new Instruction(Opcode.AND_INDY, AddressMode.IndirectY, "AND", 5) },

                // Exclusive-OR Memory with Accumulator
                { Opcode.EOR_IMM, new Instruction(Opcode.EOR_IMM, AddressMode.Immediate, "EOR", 2) },
                { Opcode.EOR_ZP, new Instruction(Opcode.EOR_ZP, AddressMode.ZeroPage, "EOR", 3) },
                { Opcode.EOR_ZPX, new Instruction(Opcode.EOR_ZPX, AddressMode.ZeroPageX, "EOR", 4) },
                { Opcode.EOR_ABS, new Instruction(Opcode.EOR_ABS, AddressMode.Absolute, "EOR", 4) },
                { Opcode.EOR_ABSX, new Instruction(Opcode.EOR_ABSX, AddressMode.AbsoluteX, "EOR", 4) },
                { Opcode.EOR_ABSY, new Instruction(Opcode.EOR_ABSY, AddressMode.AbsoluteY, "EOR", 4) },
                { Opcode.EOR_INDX, new Instruction(Opcode.EOR_INDX, AddressMode.IndirectX, "EOR", 6) },
                { Opcode.EOR_INDY, new Instruction(Opcode.EOR_INDY, AddressMode.IndirectY, "EOR", 5) },

                // OR Memory with Accumulator
                { Opcode.ORA_IMM, new Instruction(Opcode.ORA_IMM, AddressMode.Immediate, "ORA", 2) },
                { Opcode.ORA_ZP, new Instruction(Opcode.ORA_ZP, AddressMode.ZeroPage, "ORA", 3) },
                { Opcode.ORA_ZPX, new Instruction(Opcode.ORA_ZPX, AddressMode.ZeroPageX, "ORA", 4) },
                { Opcode.ORA_ABS, new Instruction(Opcode.ORA_ABS, AddressMode.Absolute, "ORA", 4) },
                { Opcode.ORA_ABSX, new Instruction(Opcode.ORA_ABSX, AddressMode.AbsoluteX, "ORA", 4) },
                { Opcode.ORA_ABSY, new Instruction(Opcode.ORA_ABSY, AddressMode.AbsoluteY, "ORA", 4) },
                { Opcode.ORA_INDX, new Instruction(Opcode.ORA_INDX, AddressMode.IndirectX, "ORA", 6) },
                { Opcode.ORA_INDY, new Instruction(Opcode.ORA_INDY, AddressMode.IndirectY, "ORA", 5) },

                // Shift Left One Bit (Memory or Accumulator)
                { Opcode.ASL_ACC, new Instruction(Opcode.ASL_ACC, AddressMode.Accumulator, "ASL", 2) },
                { Opcode.ASL_ZP, new Instruction(Opcode.ASL_ZP, AddressMode.ZeroPage, "ASL", 5) },
                { Opcode.ASL_ZPX, new Instruction(Opcode.ASL_ZPX, AddressMode.ZeroPageX, "ASL", 6) },
                { Opcode.ASL_ABS, new Instruction(Opcode.ASL_ABS, AddressMode.Absolute, "ASL", 6) },
                { Opcode.ASL_ABSX, new Instruction(Opcode.ASL_ABSX, AddressMode.AbsoluteX, "ASL", 7) },

                // Shift One Bit Right (Memory or Accumulator)
                { Opcode.LSR_ACC, new Instruction(Opcode.LSR_ACC, AddressMode.Accumulator, "LSR", 2) },
                { Opcode.LSR_ZP, new Instruction(Opcode.LSR_ZP, AddressMode.ZeroPage, "LSR", 5) },
                { Opcode.LSR_ZPX, new Instruction(Opcode.LSR_ZPX, AddressMode.ZeroPageX, "LSR", 6) },
                { Opcode.LSR_ABS, new Instruction(Opcode.LSR_ABS, AddressMode.Absolute, "LSR", 6) },
                { Opcode.LSR_ABSX, new Instruction(Opcode.LSR_ABSX, AddressMode.AbsoluteX, "LSR", 7) },

                // Rotate One Bit Left (Memory or Accumulator)
                { Opcode.ROL_ACC, new Instruction(Opcode.ROL_ACC, AddressMode.Accumulator, "ROL", 2) },
                { Opcode.ROL_ZP, new Instruction(Opcode.ROL_ZP, AddressMode.ZeroPage, "ROL", 5) },
                { Opcode.ROL_ZPX, new Instruction(Opcode.ROL_ZPX, AddressMode.ZeroPageX, "ROL", 6) },
                { Opcode.ROL_ABS, new Instruction(Opcode.ROL_ABS, AddressMode.Absolute, "ROL", 6) },
                { Opcode.ROL_ABSX, new Instruction(Opcode.ROL_ABSX, AddressMode.AbsoluteX, "ROL", 7) },

                // Rotate One Bit Right (Memory or Accumulator)
                { Opcode.ROR_ACC, new Instruction(Opcode.ROR_ACC, AddressMode.Accumulator, "ROR", 2) },
                { Opcode.ROR_ZP, new Instruction(Opcode.ROR_ZP, AddressMode.ZeroPage, "ROR", 5) },
                { Opcode.ROR_ZPX, new Instruction(Opcode.ROR_ZPX, AddressMode.ZeroPageX, "ROR", 6) },
                { Opcode.ROR_ABS, new Instruction(Opcode.ROR_ABS, AddressMode.Absolute, "ROR", 6) },
                { Opcode.ROR_ABSX, new Instruction(Opcode.ROR_ABSX, AddressMode.AbsoluteX, "ROR", 7) },

                // Branch on Result not Zero
                { Opcode.BNE, new Instruction(Opcode.BNE, AddressMode.Relative, "BNE", 2) },

                // Branch on Result Minus
                { Opcode.BMI, new Instruction(Opcode.BMI, AddressMode.Relative, "BMI", 2) },

                // Branch on Carry Clear
                { Opcode.BCC, new Instruction(Opcode.BCC, AddressMode.Relative, "BCC", 2) },

                // Branch on Carry Set
                { Opcode.BCS, new Instruction(Opcode.BCS, AddressMode.Relative, "BCS", 2) },

                // Branch on Result Zero
                { Opcode.BEQ, new Instruction(Opcode.BEQ, AddressMode.Relative, "BEQ", 2) },

                // Branch on Result Plus
                { Opcode.BPL, new Instruction(Opcode.BPL, AddressMode.Relative, "BPL", 2) },

                // Branch on Overflow Clear
                { Opcode.BVC, new Instruction(Opcode.BVC, AddressMode.Relative, "BVC", 2) },

                // Branch on Overflow Set
                { Opcode.BVS, new Instruction(Opcode.BVS, AddressMode.Relative, "BVS", 2) },

                // Clear Carry Flag
                { Opcode.CLC, new Instruction(Opcode.CLC, AddressMode.Implied, "CLC", 2) },

                // Clear Decimal Mode
                { Opcode.CLD, new Instruction(Opcode.CLD, AddressMode.Implied, "CLD", 2) },

                // Clear Interrupt Disable Bit
                { Opcode.CLI, new Instruction(Opcode.CLI, AddressMode.Implied, "CLI", 2) },

                // Clear Overflow Flag
                { Opcode.CLV, new Instruction(Opcode.CLV, AddressMode.Implied, "CLV", 2) },

                // Set Carry Flag
                { Opcode.SEC, new Instruction(Opcode.SEC, AddressMode.Implied, "SEC", 2) },

                // Set Decimal Flag
                { Opcode.SED, new Instruction(Opcode.SED, AddressMode.Implied, "SED", 2) },

                // Set Interrupt Disable Status
                { Opcode.SEI, new Instruction(Opcode.SEI, AddressMode.Implied, "SEI", 2) },

                // Decrement Memory by One
                { Opcode.DEC_ZP, new Instruction(Opcode.DEC_ZP, AddressMode.ZeroPage, "DEC", 5) },
                { Opcode.DEC_ZPX, new Instruction(Opcode.DEC_ZPX, AddressMode.ZeroPageX, "DEC", 6) },
                { Opcode.DEC_ABS, new Instruction(Opcode.DEC_ABS, AddressMode.Absolute, "DEC", 3) },
                { Opcode.DEC_ABSX, new Instruction(Opcode.DEC_ABSX, AddressMode.AbsoluteX, "DEC", 7) },

                // Decrement Index X by One
                { Opcode.DEX, new Instruction(Opcode.DEX, AddressMode.Implied, "DEX", 2) },

                // Decrement Index Y by One
                { Opcode.DEY, new Instruction(Opcode.DEY, AddressMode.Implied, "DEY", 2) },

                // Increment Memory by One
                { Opcode.INC_ZP, new Instruction(Opcode.INC_ZP, AddressMode.ZeroPage, "INC", 5) },
                { Opcode.INC_ZPX, new Instruction(Opcode.INC_ZPX, AddressMode.ZeroPageX, "INC", 6) },
                { Opcode.INC_ABS, new Instruction(Opcode.INC_ABS, AddressMode.Absolute, "INC", 6) },
                { Opcode.INC_ABSX, new Instruction(Opcode.INC_ABSX, AddressMode.AbsoluteX, "INC", 7) },

                // Increment Index X by One
                { Opcode.INX, new Instruction(Opcode.INX, AddressMode.Implied, "INX", 2) },

                // Increment Index Y by One
                { Opcode.INY, new Instruction(Opcode.INY, AddressMode.Implied, "INY", 2) },

                // Jump to New Location
                { Opcode.JMP_ABS, new Instruction(Opcode.JMP_ABS, AddressMode.Absolute, "JMP", 3) },
                { Opcode.JMP_IND, new Instruction(Opcode.JMP_IND, AddressMode.Indirect, "JMP", 5) },

                // Jump to New Location Saving Return Address
                { Opcode.JSR, new Instruction(Opcode.JSR, AddressMode.Absolute, "JSR", 6) },

                // Return from Interrupt
                { Opcode.RTI, new Instruction(Opcode.RTI, AddressMode.Implied, "RTI", 6) },

                // Return from Subroutine
                { Opcode.RTS, new Instruction(Opcode.RTS, AddressMode.Implied, "RTS", 6) },

                // Push Accumulator on Stack
                { Opcode.PHA, new Instruction(Opcode.PHA, AddressMode.Implied, "PHA", 3) },

                // Push Processor Status on Stack
                { Opcode.PHP, new Instruction(Opcode.PHP, AddressMode.Implied, "PHP", 3) },

                // Pull Accumulator from Stack
                { Opcode.PLA, new Instruction(Opcode.PLA, AddressMode.Implied, "PLA", 4) },

                // Pull Processor Status from Stack
                { Opcode.PLP, new Instruction(Opcode.PLP, AddressMode.Implied, "PLP", 4) },

                // Transfer Accumulator to Index X
                { Opcode.TAX, new Instruction(Opcode.TAX, AddressMode.Implied, "TAX", 2) },

                // Transfer Accumulator to Index Y
                { Opcode.TAY, new Instruction(Opcode.TAY, AddressMode.Implied, "TAY", 2) },

                // Transfer Stack Pointer to Index X
                { Opcode.TSX, new Instruction(Opcode.TSX, AddressMode.Implied, "TSX", 2) },

                // Transfer Index X to Accumulator
                { Opcode.TXA, new Instruction(Opcode.TXA, AddressMode.Implied, "TXA", 2) },

                // Transfer Index X to Stack Register
                { Opcode.TXS, new Instruction(Opcode.TXS, AddressMode.Implied, "TXS", 2) },

                // Transfer Index Y to Accumulator
                { Opcode.TYA, new Instruction(Opcode.TYA, AddressMode.Implied, "TYA", 2) },

                // Test Bits in Memory with Accumulator
                { Opcode.BIT_ZP, new Instruction(Opcode.BIT_ZP, AddressMode.ZeroPage, "BIT", 3) },
                { Opcode.BIT_ABS, new Instruction(Opcode.BIT_ABS, AddressMode.Absolute, "BIT", 4) },

                // No Operation
                { Opcode.NOP, new Instruction(Opcode.NOP, AddressMode.Implied, "NOP", 2) },

                // Force Break
                { Opcode.BRK, new Instruction(Opcode.BRK, AddressMode.Implied, "BRK", 7) }
            };
        }

        public static Instruction GetInstruction(Opcode opcode)
        {
            if (!instructions.ContainsKey(opcode))
                throw new ArgumentException("Unsupported opcode given.");

            return instructions[opcode];
        }
    }
}
