namespace CPUSimulator
{
    partial class SimulatorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.operationsTable = new System.Windows.Forms.DataGridView();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Opcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.runBtn = new System.Windows.Forms.Button();
            this.nextBtn = new System.Windows.Forms.Button();
            this.resetBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.accumulator = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.TextBox();
            this.programCounter = new System.Windows.Forms.TextBox();
            this.stackPointer = new System.Windows.Forms.TextBox();
            this.registerY = new System.Windows.Forms.TextBox();
            this.registerX = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.zeroFlag = new System.Windows.Forms.CheckBox();
            this.overflowFlag = new System.Windows.Forms.CheckBox();
            this.breakFlag = new System.Windows.Forms.CheckBox();
            this.decimalFlag = new System.Windows.Forms.CheckBox();
            this.interruptFlag = new System.Windows.Forms.CheckBox();
            this.negativeFlag = new System.Windows.Forms.CheckBox();
            this.carryFlag = new System.Windows.Forms.CheckBox();
            this.hardResetBtn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.programOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.loadProgramFromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.memoryTabControl = new System.Windows.Forms.TabControl();
            this.prevPageBtn = new System.Windows.Forms.Button();
            this.nextPageBtn = new System.Windows.Forms.Button();
            this.currentPageBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.consoleControl = new CPUSimulator.ConsoleControl.ConsoleControl();
            ((System.ComponentModel.ISupportInitialize)(this.operationsTable)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // operationsTable
            // 
            this.operationsTable.AllowUserToAddRows = false;
            this.operationsTable.AllowUserToDeleteRows = false;
            this.operationsTable.AllowUserToResizeColumns = false;
            this.operationsTable.AllowUserToResizeRows = false;
            this.operationsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.operationsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Address,
            this.Opcode,
            this.Operand});
            this.operationsTable.Location = new System.Drawing.Point(16, 47);
            this.operationsTable.Name = "operationsTable";
            this.operationsTable.ReadOnly = true;
            this.operationsTable.Size = new System.Drawing.Size(313, 508);
            this.operationsTable.TabIndex = 1;
            // 
            // Address
            // 
            this.Address.DataPropertyName = "Address";
            this.Address.HeaderText = "Address";
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            this.Address.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Address.Width = 90;
            // 
            // Opcode
            // 
            this.Opcode.DataPropertyName = "Opcode";
            this.Opcode.HeaderText = "Opcode";
            this.Opcode.Name = "Opcode";
            this.Opcode.ReadOnly = true;
            this.Opcode.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Opcode.Width = 80;
            // 
            // Operand
            // 
            this.Operand.DataPropertyName = "Operand";
            this.Operand.HeaderText = "Operand";
            this.Operand.Name = "Operand";
            this.Operand.ReadOnly = true;
            this.Operand.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Program operations";
            // 
            // runBtn
            // 
            this.runBtn.Location = new System.Drawing.Point(337, 518);
            this.runBtn.Name = "runBtn";
            this.runBtn.Size = new System.Drawing.Size(94, 37);
            this.runBtn.TabIndex = 4;
            this.runBtn.Text = "Run";
            this.runBtn.UseVisualStyleBackColor = true;
            this.runBtn.Click += new System.EventHandler(this.runBtn_Click);
            // 
            // nextBtn
            // 
            this.nextBtn.Location = new System.Drawing.Point(437, 518);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(101, 37);
            this.nextBtn.TabIndex = 5;
            this.nextBtn.Text = "Next";
            this.nextBtn.UseVisualStyleBackColor = true;
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // resetBtn
            // 
            this.resetBtn.Location = new System.Drawing.Point(544, 518);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(101, 37);
            this.resetBtn.TabIndex = 6;
            this.resetBtn.Text = "Soft reset";
            this.resetBtn.UseVisualStyleBackColor = true;
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(753, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Memory dump";
            // 
            // accumulator
            // 
            this.accumulator.Location = new System.Drawing.Point(21, 44);
            this.accumulator.Name = "accumulator";
            this.accumulator.ReadOnly = true;
            this.accumulator.Size = new System.Drawing.Size(120, 22);
            this.accumulator.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.status);
            this.groupBox1.Controls.Add(this.programCounter);
            this.groupBox1.Controls.Add(this.stackPointer);
            this.groupBox1.Controls.Add(this.registerY);
            this.groupBox1.Controls.Add(this.registerX);
            this.groupBox1.Controls.Add(this.accumulator);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox1.Location = new System.Drawing.Point(335, 329);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(308, 183);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registers";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(167, 131);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Status";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(167, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Program Counter";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(167, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Stack Pointer";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Index Y";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Index  X";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Accumulator";
            // 
            // status
            // 
            this.status.Location = new System.Drawing.Point(167, 147);
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Size = new System.Drawing.Size(120, 22);
            this.status.TabIndex = 16;
            // 
            // programCounter
            // 
            this.programCounter.Location = new System.Drawing.Point(167, 44);
            this.programCounter.Name = "programCounter";
            this.programCounter.ReadOnly = true;
            this.programCounter.Size = new System.Drawing.Size(120, 22);
            this.programCounter.TabIndex = 15;
            // 
            // stackPointer
            // 
            this.stackPointer.Location = new System.Drawing.Point(167, 95);
            this.stackPointer.Name = "stackPointer";
            this.stackPointer.ReadOnly = true;
            this.stackPointer.Size = new System.Drawing.Size(120, 22);
            this.stackPointer.TabIndex = 14;
            // 
            // registerY
            // 
            this.registerY.Location = new System.Drawing.Point(22, 147);
            this.registerY.Name = "registerY";
            this.registerY.ReadOnly = true;
            this.registerY.Size = new System.Drawing.Size(120, 22);
            this.registerY.TabIndex = 13;
            // 
            // registerX
            // 
            this.registerX.Location = new System.Drawing.Point(22, 95);
            this.registerX.Name = "registerX";
            this.registerX.ReadOnly = true;
            this.registerX.Size = new System.Drawing.Size(120, 22);
            this.registerX.TabIndex = 12;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.zeroFlag);
            this.groupBox2.Controls.Add(this.overflowFlag);
            this.groupBox2.Controls.Add(this.breakFlag);
            this.groupBox2.Controls.Add(this.decimalFlag);
            this.groupBox2.Controls.Add(this.interruptFlag);
            this.groupBox2.Controls.Add(this.negativeFlag);
            this.groupBox2.Controls.Add(this.carryFlag);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox2.Location = new System.Drawing.Point(649, 335);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(101, 177);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Status Flags";
            // 
            // zeroFlag
            // 
            this.zeroFlag.AutoCheck = false;
            this.zeroFlag.AutoSize = true;
            this.zeroFlag.Location = new System.Drawing.Point(12, 154);
            this.zeroFlag.Name = "zeroFlag";
            this.zeroFlag.Size = new System.Drawing.Size(50, 17);
            this.zeroFlag.TabIndex = 6;
            this.zeroFlag.Text = "Zero";
            this.zeroFlag.UseVisualStyleBackColor = true;
            // 
            // overflowFlag
            // 
            this.overflowFlag.AutoCheck = false;
            this.overflowFlag.AutoSize = true;
            this.overflowFlag.Location = new System.Drawing.Point(12, 132);
            this.overflowFlag.Name = "overflowFlag";
            this.overflowFlag.Size = new System.Drawing.Size(73, 17);
            this.overflowFlag.TabIndex = 5;
            this.overflowFlag.Text = "Overflow";
            this.overflowFlag.UseVisualStyleBackColor = true;
            // 
            // breakFlag
            // 
            this.breakFlag.AutoCheck = false;
            this.breakFlag.AutoSize = true;
            this.breakFlag.Location = new System.Drawing.Point(12, 109);
            this.breakFlag.Name = "breakFlag";
            this.breakFlag.Size = new System.Drawing.Size(55, 17);
            this.breakFlag.TabIndex = 4;
            this.breakFlag.Text = "Break";
            this.breakFlag.UseVisualStyleBackColor = true;
            // 
            // decimalFlag
            // 
            this.decimalFlag.AutoCheck = false;
            this.decimalFlag.AutoSize = true;
            this.decimalFlag.Location = new System.Drawing.Point(12, 86);
            this.decimalFlag.Name = "decimalFlag";
            this.decimalFlag.Size = new System.Drawing.Size(67, 17);
            this.decimalFlag.TabIndex = 3;
            this.decimalFlag.Text = "Decimal";
            this.decimalFlag.UseVisualStyleBackColor = true;
            // 
            // interruptFlag
            // 
            this.interruptFlag.AutoCheck = false;
            this.interruptFlag.AutoSize = true;
            this.interruptFlag.Location = new System.Drawing.Point(12, 63);
            this.interruptFlag.Name = "interruptFlag";
            this.interruptFlag.Size = new System.Drawing.Size(72, 17);
            this.interruptFlag.TabIndex = 2;
            this.interruptFlag.Text = "Interrupt";
            this.interruptFlag.UseVisualStyleBackColor = true;
            // 
            // negativeFlag
            // 
            this.negativeFlag.AutoCheck = false;
            this.negativeFlag.AutoSize = true;
            this.negativeFlag.Location = new System.Drawing.Point(12, 40);
            this.negativeFlag.Name = "negativeFlag";
            this.negativeFlag.Size = new System.Drawing.Size(73, 17);
            this.negativeFlag.TabIndex = 1;
            this.negativeFlag.Text = "Negative";
            this.negativeFlag.UseVisualStyleBackColor = true;
            // 
            // carryFlag
            // 
            this.carryFlag.AutoCheck = false;
            this.carryFlag.AutoSize = true;
            this.carryFlag.Location = new System.Drawing.Point(12, 18);
            this.carryFlag.Name = "carryFlag";
            this.carryFlag.Size = new System.Drawing.Size(53, 17);
            this.carryFlag.TabIndex = 0;
            this.carryFlag.Text = "Carry";
            this.carryFlag.UseVisualStyleBackColor = true;
            // 
            // hardResetBtn
            // 
            this.hardResetBtn.Location = new System.Drawing.Point(651, 518);
            this.hardResetBtn.Name = "hardResetBtn";
            this.hardResetBtn.Size = new System.Drawing.Size(101, 37);
            this.hardResetBtn.TabIndex = 14;
            this.hardResetBtn.Text = "Hard reset";
            this.hardResetBtn.UseVisualStyleBackColor = true;
            this.hardResetBtn.Click += new System.EventHandler(this.hardResetBtn_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programOptions});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1086, 24);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // programOptions
            // 
            this.programOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadProgramFromFileToolStripMenuItem});
            this.programOptions.Name = "programOptions";
            this.programOptions.Size = new System.Drawing.Size(61, 20);
            this.programOptions.Text = "Options";
            // 
            // loadProgramFromFileToolStripMenuItem
            // 
            this.loadProgramFromFileToolStripMenuItem.Name = "loadProgramFromFileToolStripMenuItem";
            this.loadProgramFromFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadProgramFromFileToolStripMenuItem.Text = "Load program file";
            this.loadProgramFromFileToolStripMenuItem.Click += new System.EventHandler(this.loadProgramFromFileToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(335, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Input/Output";
            // 
            // memoryTabControl
            // 
            this.memoryTabControl.Location = new System.Drawing.Point(759, 47);
            this.memoryTabControl.Name = "memoryTabControl";
            this.memoryTabControl.SelectedIndex = 0;
            this.memoryTabControl.Size = new System.Drawing.Size(313, 465);
            this.memoryTabControl.TabIndex = 19;
            this.memoryTabControl.SelectedIndexChanged += new System.EventHandler(this.memoryTabControl_SelectedIndexChanged);
            // 
            // prevPageBtn
            // 
            this.prevPageBtn.Location = new System.Drawing.Point(759, 518);
            this.prevPageBtn.Name = "prevPageBtn";
            this.prevPageBtn.Size = new System.Drawing.Size(101, 37);
            this.prevPageBtn.TabIndex = 20;
            this.prevPageBtn.Text = "Previous page";
            this.prevPageBtn.UseVisualStyleBackColor = true;
            this.prevPageBtn.Click += new System.EventHandler(this.prevPageBtn_Click);
            // 
            // nextPageBtn
            // 
            this.nextPageBtn.Location = new System.Drawing.Point(971, 518);
            this.nextPageBtn.Name = "nextPageBtn";
            this.nextPageBtn.Size = new System.Drawing.Size(101, 37);
            this.nextPageBtn.TabIndex = 21;
            this.nextPageBtn.Text = "Next page";
            this.nextPageBtn.UseVisualStyleBackColor = true;
            this.nextPageBtn.Click += new System.EventHandler(this.nextPageBtn_Click);
            // 
            // currentPageBox
            // 
            this.currentPageBox.Location = new System.Drawing.Point(874, 531);
            this.currentPageBox.Name = "currentPageBox";
            this.currentPageBox.Size = new System.Drawing.Size(84, 22);
            this.currentPageBox.TabIndex = 22;
            this.currentPageBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.currentPageBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.currentPageBox_KeyUp);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.Location = new System.Drawing.Point(899, 518);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Page";
            // 
            // consoleControl
            // 
            this.consoleControl.IsInputEnabled = true;
            this.consoleControl.Location = new System.Drawing.Point(335, 47);
            this.consoleControl.Name = "consoleControl";
            this.consoleControl.Size = new System.Drawing.Size(418, 276);
            this.consoleControl.TabIndex = 18;
            this.consoleControl.OnConsoleInput += new CPUSimulator.ConsoleControl.ConsoleEventHandler(this.consoleControl_OnConsoleInput);
            // 
            // SimulatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 567);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.currentPageBox);
            this.Controls.Add(this.nextPageBtn);
            this.Controls.Add(this.prevPageBtn);
            this.Controls.Add(this.memoryTabControl);
            this.Controls.Add(this.consoleControl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hardResetBtn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.resetBtn);
            this.Controls.Add(this.nextBtn);
            this.Controls.Add(this.runBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.operationsTable);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SimulatorForm";
            this.Text = "6502 Simulator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SimulatorForm_FormClosing);
            this.Load += new System.EventHandler(this.SimulatorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.operationsTable)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView operationsTable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button runBtn;
        private System.Windows.Forms.Button nextBtn;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox accumulator;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox registerY;
        private System.Windows.Forms.TextBox registerX;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox status;
        private System.Windows.Forms.TextBox programCounter;
        private System.Windows.Forms.TextBox stackPointer;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox interruptFlag;
        private System.Windows.Forms.CheckBox negativeFlag;
        private System.Windows.Forms.CheckBox carryFlag;
        private System.Windows.Forms.CheckBox decimalFlag;
        private System.Windows.Forms.CheckBox breakFlag;
        private System.Windows.Forms.CheckBox zeroFlag;
        private System.Windows.Forms.CheckBox overflowFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn Opcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Operand;
        private System.Windows.Forms.Button hardResetBtn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem programOptions;
        private System.Windows.Forms.ToolStripMenuItem loadProgramFromFileToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private ConsoleControl.ConsoleControl consoleControl;
        private System.Windows.Forms.TabControl memoryTabControl;
        private System.Windows.Forms.Button prevPageBtn;
        private System.Windows.Forms.Button nextPageBtn;
        private System.Windows.Forms.TextBox currentPageBox;
        private System.Windows.Forms.Label label10;
    }
}

