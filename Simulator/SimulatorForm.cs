using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simulator
{
    public partial class SimulatorForm : Form
    {
        Simulator simulator;
        StringBuilder consoleInput;
        Dictionary<ushort, int> operationsIndexMap;
        Dictionary<string, byte[]> devicesMemoryDump;

        /// <summary>
        /// Constructs a new SimulatorForm.
        /// </summary>
        public SimulatorForm()
        {
            InitializeComponent();

            // Initialize DataTable of executed operations
            DataTable operations = new DataTable();
            operations.Columns.Add(new DataColumn("Address", Type.GetType("System.UInt16")));
            operations.Columns.Add(new DataColumn("Opcode"));
            operations.Columns.Add(new DataColumn("Operand"));
            operationsTable.DataSource = operations;
            currentPageBox.Text = "1";

            operationsIndexMap = new Dictionary<ushort, int>();
            devicesMemoryDump = new Dictionary<string, byte[]>();
            consoleInput = new StringBuilder();
        }

        /// <summary>
        /// Updates the part of the UI displaying the content of each register and the DataTable window of all executed operations.
        /// </summary>
        /// <param name="updateEventArgs">The UpdateUIEventArgs instance containing the state of the CPU and the last executed operation.</param>
        public void UpdateStateUI(UpdateUIEventArgs updateEventArgs)
        {
            // Check if we're on a thread other than the UI thread
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(() => UpdateStateUI(updateEventArgs)));
                return;
            }

            UpdateRegistersUI(updateEventArgs);
            UpdateOperationsUI(updateEventArgs);
        }

        /// <summary>
        /// Updates the part of the UI displaying the content of each register.
        /// </summary>
        /// <param name="updateEventArgs">The UpdateUIEventArgs instance containing the state of the CPU and the last executed operation.</param>
        public void UpdateRegistersUI(UpdateUIEventArgs updateEventArgs)
        {
            if (accumulator.Tag == null || (byte)accumulator.Tag != updateEventArgs.Accumulator)
            {
                accumulator.Tag = updateEventArgs.Accumulator;
                accumulator.Text = updateEventArgs.Accumulator.ToString();
            }

            if (registerX.Tag == null || (byte)registerX.Tag != updateEventArgs.RegisterX)
            {
                registerX.Tag = updateEventArgs.RegisterX;
                registerX.Text = updateEventArgs.RegisterX.ToString();
            }

            if (registerY.Tag == null || (byte)registerY.Tag != updateEventArgs.RegisterY)
            {
                registerY.Tag = updateEventArgs.RegisterY;
                registerY.Text = updateEventArgs.RegisterY.ToString();
            }

            if (stackPointer.Tag == null || (byte)stackPointer.Tag != updateEventArgs.StackPointer)
            {
                stackPointer.Tag = updateEventArgs.StackPointer;
                stackPointer.Text = updateEventArgs.StackPointer.ToString();
            }

            if (programCounter.Tag == null || (ushort)programCounter.Tag != updateEventArgs.ProgramCounter)
            {
                programCounter.Tag = updateEventArgs.ProgramCounter;
                programCounter.Text = updateEventArgs.ProgramCounter.ToString();
            }

            if (status.Tag == null || (byte)status.Tag != updateEventArgs.Status)
            {
                status.Tag = updateEventArgs.Status;
                status.Text = updateEventArgs.Status.ToString();
            }

            if (carryFlag.Checked != updateEventArgs.HasCarryFlag)
                carryFlag.Checked = updateEventArgs.HasCarryFlag;

            if (negativeFlag.Checked != updateEventArgs.HasNegativeFlag)
                negativeFlag.Checked = updateEventArgs.HasNegativeFlag;

            if (interruptFlag.Checked != updateEventArgs.HasInterruptDisableFlag)
                interruptFlag.Checked = updateEventArgs.HasInterruptDisableFlag;

            if (breakFlag.Checked != updateEventArgs.HasBreakFlag)
                breakFlag.Checked = updateEventArgs.HasBreakFlag;

            if (decimalFlag.Checked != updateEventArgs.HasDecimalFlag)
                decimalFlag.Checked = updateEventArgs.HasDecimalFlag;

            if (overflowFlag.Checked != updateEventArgs.HasOverflowFlag)
                overflowFlag.Checked = updateEventArgs.HasOverflowFlag;

            if (zeroFlag.Checked != updateEventArgs.HasZeroFlag)
                zeroFlag.Checked = updateEventArgs.HasZeroFlag;
        }

        /// <summary>
        /// Updates the part of the UI displaying the DataTable window of all executed operations.
        /// </summary>
        /// <param name="updateEventArgs">The UpdateUIEventArgs instance contaning the state of the CPU and the last executed operation.</param>
        public void UpdateOperationsUI(UpdateUIEventArgs updateEventArgs)
        {
            if (updateEventArgs.OperationAddress == 0)
                return;

            operationsTable.ClearSelection();
            if (!operationsIndexMap.ContainsKey(updateEventArgs.OperationAddress))
            {
                DataTable dataTable = (DataTable)operationsTable.DataSource;
                DataRow row = dataTable.NewRow();
                row["Address"] = updateEventArgs.OperationAddress;
                row["Opcode"] = updateEventArgs.OperationOpName;
                row["Operand"] = updateEventArgs.OperationOperand;
                dataTable.Rows.Add(row);
                operationsTable.CurrentCell = operationsTable[1, dataTable.Rows.Count - 1];
                operationsTable.Rows[operationsTable.Rows.Count - 1].Selected = true;
                operationsIndexMap[updateEventArgs.OperationAddress] = operationsTable.Rows.Count - 1;
            }
            else
            {
                DataGridViewRow row = operationsTable.Rows[operationsIndexMap[updateEventArgs.OperationAddress]];
                row.Selected = true;
                operationsTable.CurrentCell = operationsTable[1, row.Index];
            }
        }

        /// <summary>
        /// Writes the output char to the Console control.
        /// </summary>
        /// <param name="outputChar">The output char.</param>
        public void WriteConsoleOutput(byte outputChar)
        {
            BeginInvoke(new Action(() =>
            {
                consoleControl.WriteOutput(Encoding.ASCII.GetString(new byte[] { outputChar }), Color.White);
            }));
        }

        /// <summary>
        /// Checks if there is some input from the Console control.
        /// </summary>
        public bool HasConsoleInput()
        {
            return consoleInput.Length > 0;
        }

        /// <summary>
        /// Gets the input char from the Console control.
        /// </summary>
        public byte GetConsoleInput() {
            byte input = Convert.ToByte(consoleInput.ToString().First());
            consoleInput.Remove(0, 1);
            return input;
        }

        /// <summary>
        /// Updates the text of the Run button.
        /// </summary>
        /// <param name="running">True if the processor is running, false if it is stopped.</param>
        public void UpdateRunButton(bool running)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(() => UpdateRunButton(running)));
                return;
            }

            runBtn.Text = running ? "Stop" : "Run";
        }

        /// <summary>
        /// Reinitializes the Memory dump tabs UI and fills it with dumped data from the memory.
        /// </summary>
        /// <param name="devicesMemoryDump">The dumped memory data of each device.</param>
        public void InitializeMemoryDump(Dictionary<string, byte[]> devicesMemoryDump)
        {
            memoryTabControl.TabPages.Clear();
            this.devicesMemoryDump = devicesMemoryDump;
            foreach (string deviceName in devicesMemoryDump.Keys)
            {
                TabPage tab = new TabPage(deviceName);
                tab.Name = deviceName;
                memoryTabControl.TabPages.Add(tab);

                RichTextBox rtb = new RichTextBox();
                rtb.Name = "memoryRichTextBox";
                rtb.Dock = DockStyle.Fill;
                rtb.BorderStyle = BorderStyle.None;
                rtb.ReadOnly = true;

                tab.Controls.Add(rtb);
            }

            SetCurrentMemoryPage(1);
        }

        /// <summary>
        /// Updates the dumped memory data used by the Memory dump window and refreshes the currently opened tab.
        /// </summary>
        /// <param name="devicesMemoryDump">The dumped memory data of each device.</param>
        public void UpdateMemoryDump(Dictionary<string, byte[]> devicesMemoryDump)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(() => UpdateMemoryDump(devicesMemoryDump)));
                return;
            }

            this.devicesMemoryDump = devicesMemoryDump;
            SetCurrentMemoryPage(Convert.ToInt32(currentPageBox.Text));
        }

        /// <summary>
        /// Sets the current memory page index and displays the data in the hex view.
        /// </summary>
        /// <param name="page">The page index.</param>
        private void SetCurrentMemoryPage(int page)
        {
            TabPage currentTab = memoryTabControl.SelectedTab;
            if (currentTab == null)
                return;

            byte[] deviceMemoryDump = devicesMemoryDump[currentTab.Name];
            int pageSize = Math.Min(0x200, deviceMemoryDump.Length);
            int pageStartAddress = (page - 1) * 0x200;
            if (page <= 0 || pageStartAddress + pageSize > deviceMemoryDump.Length)
            {
                currentPageBox.Text = currentPageBox.Tag.ToString();
                return;
            }

            byte[] pageBytes = new byte[pageSize];
            Array.Copy(deviceMemoryDump, pageStartAddress, pageBytes, 0, pageSize);
            //string memoryHexDump = BitConverter.ToString(pageBytes).Replace("-", " ");

            // TODO: MAKE FASTER UTILITY METHOD FOR THIS
            int bytesPerLine = 16;
            string hexDump = pageBytes.Select((c, i) => new { Char = c, Chunk = i / bytesPerLine })
                .GroupBy(c => c.Chunk)
                .Select(g => g.Select(c => String.Format("{0:X2} ", c.Char))
                    .Aggregate((s, i) => s + i))
                .Select((s, i) => String.Format("{0:X4}:  {1}", pageStartAddress + i * bytesPerLine, s))
                .Aggregate("", (s, i) => s + i + Environment.NewLine);

            currentTab.Controls["memoryRichTextBox"].Text = hexDump;
            currentPageBox.Text = page.ToString();
            currentPageBox.Tag = page;
        }

        /// <summary>
        /// Clears the UI.
        /// </summary>
        private void ClearUI()
        {
            operationsIndexMap.Clear();
            ((DataTable)operationsTable.DataSource).Clear();
            consoleControl.ClearOutput();
        }

        /// <summary>
        /// Handles the Click event of the runBtn.
        /// This handler starts the simulation.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.EventArgs"/> instance containing the event data.</param>
        private async void runBtn_Click(object sender, EventArgs e)
        {
            await simulator.RunSimulation();
        }

        /// <summary>
        /// Handles the Click event of the nextBtn.
        /// This handler moves the simulation by one step.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.EventArgs"/> instance containing the event data.</param>
        private async void nextBtn_Click(object sender, EventArgs e)
        {
            await simulator.MoveToNextOperation();
        }

        /// <summary>
        /// Handles the Click event of the resetBtn.
        /// This handler waits until the simulation is stopped and then resets it.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.EventArgs"/> instance containing the event data.</param>
        private async void resetBtn_Click(object sender, EventArgs e)
        {
            await simulator.StopSimulation();
            simulator.ResetSimulation();
        }

        /// <summary>
        /// Handles the Click event of the hardResetBtn.
        /// This handler waits until the simulation is stopped, clears the UI and then hard resets the simulation.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.EventArgs"/> instance containing the event data.</param>
        private async void hardResetBtn_Click(object sender, EventArgs e)
        {
            await simulator.StopSimulation();
            ClearUI();
            simulator.HardResetSimulation();
        }

        /// <summary>
        /// Handles the Click event of the loadProgramFromFileToolStripMenuItem.
        /// This handler opens the file dialog to allow user choose a program file that should be loaded.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.EventArgs"/> instance containing the event data.</param>
        private void loadProgramFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ClearUI();
                simulator.LoadProgramFromFile(openFileDialog.FileName);
            }
        }

        /// <summary>
        /// Handles the FormClosing event of the SimulatorForm.
        /// This handler delays closing of this form until the simulation is stopped.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.FormClosingEventArgs"/> instance containing the event data.</param>
        private async void SimulatorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            await simulator.StopSimulation();
        }

        /// <summary>
        /// Handles the Load event of the SimulatorForm.
        /// This handler creates a new Simulator.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.EventArgs"/> instance containing the event data.</param>
        private void SimulatorForm_Load(object sender, EventArgs e)
        {
            simulator = new Simulator(this);
        }

        /// <summary>
        /// Handles the OnConsoleInput event of the consoleControl.
        /// This handler stores the input char in the StringBuilder.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.EventArgs"/> instance containing the event data.</param>
        private void consoleControl_OnConsoleInput(object sender, ConsoleControl.ConsoleEventArgs args)
        {
            consoleInput.Append(args.Content);
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the memoryTabControl.
        /// This handler sets the first memory page as the currently displayed page.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.EventArgs"/> instance containing the event data.</param>
        private void memoryTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetCurrentMemoryPage(1);
        }

        /// <summary>
        /// Handles the Click event of the nextPageBtn.
        /// This handler increments the index of the currently displayed memory page.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.EventArgs"/> instance containing the event data.</param>
        private void nextPageBtn_Click(object sender, EventArgs e)
        {
            SetCurrentMemoryPage((int)currentPageBox.Tag + 1);
        }

        /// <summary>
        /// Handles the Click event of the prevPageBtn.
        /// This handler decrements the index of the currently displayed memory page.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.EventArgs"/> instance containing the event data.</param>
        private void prevPageBtn_Click(object sender, EventArgs e)
        {
            SetCurrentMemoryPage((int)currentPageBox.Tag - 1);
        }

        /// <summary>
        /// Handles the KeyUp event of the currentPageBox.
        /// This handler sets the index of currently displayed memory page.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.EventArgs"/> instance containing the event data.</param>
        private void currentPageBox_KeyUp(object sender, KeyEventArgs e)
        {
            SetCurrentMemoryPage(Convert.ToInt32(currentPageBox.Text));
        }
    }
}
