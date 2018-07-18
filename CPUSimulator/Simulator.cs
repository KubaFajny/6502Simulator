using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace CPUSimulator
{
    class Simulator
    {
        const short DEFAULT_START_ADDRESS = 0x200;

        SimulatorForm gui;
        CPU cpu;
        Bus bus;

        public Simulator(SimulatorForm gui)
        {
            this.gui = gui;

            InitializeComponents();
        }

        private void InitializeComponents()
        {
            bus = new Bus();
            cpu = new CPU(bus);
        }

        public void RunSimulation()
        {
            cpu.RunAll(DEFAULT_START_ADDRESS);
            UpdateGUI();
        }

        public void MoveToNextOperation()
        {
            cpu.RunNext();
            UpdateGUI();
        }

        public void ResetSimulation()
        {
            cpu.Reset(DEFAULT_START_ADDRESS);
            UpdateGUI();
        }

        public void LoadProgramFromHex(String hexStr)
        {
            int address = DEFAULT_START_ADDRESS;
            using (StringReader sr = new StringReader(hexStr))
            {
                String line;
                // TODO: rewrite this to support comments in the code
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Length == 0)
                        continue;

                    line = line.Replace(" ", "");
                    if (line.Length % 2 == 1)
                        throw new FormatException("Code text is in wrong format.");

                    byte[] bytes = new byte[line.Length / 2];
                    for (int i = 0; i < line.Length; i += 2)
                        bytes[i / 2] = Convert.ToByte(line.Substring(i, 2), 16);

                    bus.WriteToMemory(address, bytes);
                    address += bytes.Length;
                }
            }

            ParseAllLoadedOperations();
            ResetSimulation();
        }

        public void LoadProgramFromFile(String file) { }

        private void ParseAllLoadedOperations()
        {
            DataTable parsedOperations = new DataTable();
            parsedOperations.Columns.Add(new DataColumn("Address", Type.GetType("System.Int16")));
            parsedOperations.Columns.Add(new DataColumn("Opcode"));
            parsedOperations.Columns.Add(new DataColumn("Operand"));

            int address = DEFAULT_START_ADDRESS;
            byte lastOpcode = 0;
            do
            {
                byte opcode = bus.ReadFromMemory(address);
                if (opcode == 0 && lastOpcode == 0)
                {
                    address++;
                    continue;
                }

                Instruction instruction = InstructionSet.GetInstruction((Opcode)opcode);
                byte[] operand = bus.ReadFromMemory(address + 1, instruction.GetOperandSize());

                DataRow row = parsedOperations.NewRow();
                row["Address"] = address;
                row["Opcode"] = instruction.GetOpcodeName();
                row["Operand"] = instruction.GetOperandPretty(operand);
                parsedOperations.Rows.Add(row);

                address += 1 + instruction.GetOperandSize();
                lastOpcode = opcode;
            } while (address < Bus.MEMORY_SIZE);

            gui.UpdateOperations(parsedOperations);
        }

        private void UpdateGUI()
        {
            gui.UpdateRegistersFromState(cpu.GetState());
            gui.UpdateMemoryDump(bus.GetMemoryDump());
            gui.UpdateCurrentOperation(cpu.GetState().PC);
        }
    }
}

/* TESTING CODE:
// First ten fibonacci numbers at address 0xF1B - 0xF24
a9 00 85 f0 a9 01 85 f1 a2 00 a5 f1 9d 1b 0f 85 
f2 65 f0 85 f1 a5 f2 85 f0 e8 e0 0a 30 ec 00 

       LDA  #0
       STA  $F0     ; LOWER NUMBER
       LDA  #1
       STA  $F1     ; HIGHER NUMBER
       LDX  #0
LOOP:  LDA  $F1
       STA  $0F1B,X
       STA  $F2     ; OLD HIGHER NUMBER
       ADC  $F0
       STA  $F1     ; NEW HIGHER NUMBER
       LDA  $F2
       STA  $F0     ; NEW LOWER NUMBER
       INX
       CPX  #$0A    ; STOP AT FIB(10)
       BMI  LOOP
       BRK


// loop by jsr
20 09 02 20 0c 02 20 12 02 a2 00 60 e8 e0 05 d0 fb 60 00

  JSR init
  JSR loop
  JSR end

init:
  LDX #$00
  RTS

loop:
  INX
  CPX #$05
  BNE loop
  RTS

end:
  BRK
 */
