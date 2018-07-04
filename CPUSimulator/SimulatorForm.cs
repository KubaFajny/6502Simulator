using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPUSimulator
{
    public partial class SimulatorForm : Form
    {
        Simulator simulator;

        public SimulatorForm()
        {
            InitializeComponent();

            simulator = new Simulator(this);
        }

        public void UpdateRegistersFromState(CPUState state)
        {
            accumulator.Text = state.accumulator.ToString();
            registerX.Text = state.registerX.ToString();
            registerY.Text = state.registerY.ToString();
            stackPointer.Text = state.SP.ToString();
            programCounter.Text = state.PC.ToString();
            status.Text = state.status.ToString();

            carryFlag.Checked = state.HasStatusFlag(StatusFlag.Carry);
            negativeFlag.Checked = state.HasStatusFlag(StatusFlag.Negative);
            interruptFlag.Checked = state.HasStatusFlag(StatusFlag.Interrupt);
            breakFlag.Checked = state.HasStatusFlag(StatusFlag.Break);
            decimalFlag.Checked = state.HasStatusFlag(StatusFlag.Decimal);
            overflowFlag.Checked = state.HasStatusFlag(StatusFlag.Overflow);
            zeroFlag.Checked = state.HasStatusFlag(StatusFlag.Zero);
        }

        public void UpdateMemoryDump(String memoryDump)
        {
            this.memoryDump.Text = memoryDump;
        }

        public void UpdateOperations(DataTable operations)
        {
            operationsTable.DataSource = operations;
        }

        public void UpdateCurrentOperation(short programCounter)
        {
            operationsTable.ClearSelection();
            foreach (DataGridViewRow tableRow in operationsTable.Rows)
            {
                DataRow operation = ((DataRowView)tableRow.DataBoundItem).Row;
                if (programCounter == (short)operation["Address"])
                {
                    tableRow.Selected = true;
                    operationsTable.CurrentCell = operationsTable[1, tableRow.Index];
                }
                else
                    tableRow.Selected = false;
            }

        }

        private void runBtn_Click(object sender, EventArgs e)
        {
            simulator.RunSimulation();
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            simulator.MoveToNextOperation();
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            simulator.ResetSimulation();
        }

        private void loadCodeBtn_Click(object sender, EventArgs e)
        {
            simulator.LoadProgramFromHex(machineCodeText.Text);
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void machineCodeText_TextChanged(object sender, EventArgs e)
        {
        }

        private void loadFromFileBtn_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
