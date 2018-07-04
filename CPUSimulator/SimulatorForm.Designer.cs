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
            this.machineCodeText = new System.Windows.Forms.RichTextBox();
            this.operationsTable = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.runBtn = new System.Windows.Forms.Button();
            this.nextBtn = new System.Windows.Forms.Button();
            this.resetBtn = new System.Windows.Forms.Button();
            this.loadFromFileBtn = new System.Windows.Forms.Button();
            this.loadCodeBtn = new System.Windows.Forms.Button();
            this.memoryDump = new System.Windows.Forms.RichTextBox();
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
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Opcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.operationsTable)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // machineCodeText
            // 
            this.machineCodeText.Location = new System.Drawing.Point(13, 30);
            this.machineCodeText.Name = "machineCodeText";
            this.machineCodeText.Size = new System.Drawing.Size(293, 375);
            this.machineCodeText.TabIndex = 0;
            this.machineCodeText.Text = "";
            this.machineCodeText.TextChanged += new System.EventHandler(this.machineCodeText_TextChanged);
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
            this.operationsTable.Location = new System.Drawing.Point(313, 30);
            this.operationsTable.Name = "operationsTable";
            this.operationsTable.ReadOnly = true;
            this.operationsTable.Size = new System.Drawing.Size(313, 375);
            this.operationsTable.TabIndex = 1;
            this.operationsTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Machine code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(312, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Program operations";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // runBtn
            // 
            this.runBtn.Location = new System.Drawing.Point(311, 422);
            this.runBtn.Name = "runBtn";
            this.runBtn.Size = new System.Drawing.Size(101, 37);
            this.runBtn.TabIndex = 4;
            this.runBtn.Text = "Run";
            this.runBtn.UseVisualStyleBackColor = true;
            this.runBtn.Click += new System.EventHandler(this.runBtn_Click);
            // 
            // nextBtn
            // 
            this.nextBtn.Location = new System.Drawing.Point(418, 422);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(101, 37);
            this.nextBtn.TabIndex = 5;
            this.nextBtn.Text = "Next";
            this.nextBtn.UseVisualStyleBackColor = true;
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // resetBtn
            // 
            this.resetBtn.Location = new System.Drawing.Point(525, 422);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(101, 37);
            this.resetBtn.TabIndex = 6;
            this.resetBtn.Text = "Reset";
            this.resetBtn.UseVisualStyleBackColor = true;
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // loadFromFileBtn
            // 
            this.loadFromFileBtn.Location = new System.Drawing.Point(164, 422);
            this.loadFromFileBtn.Name = "loadFromFileBtn";
            this.loadFromFileBtn.Size = new System.Drawing.Size(141, 37);
            this.loadFromFileBtn.TabIndex = 7;
            this.loadFromFileBtn.Text = "Load from file";
            this.loadFromFileBtn.UseVisualStyleBackColor = true;
            this.loadFromFileBtn.Click += new System.EventHandler(this.loadFromFileBtn_Click);
            // 
            // loadCodeBtn
            // 
            this.loadCodeBtn.Location = new System.Drawing.Point(16, 422);
            this.loadCodeBtn.Name = "loadCodeBtn";
            this.loadCodeBtn.Size = new System.Drawing.Size(141, 37);
            this.loadCodeBtn.TabIndex = 8;
            this.loadCodeBtn.Text = "Load code";
            this.loadCodeBtn.UseVisualStyleBackColor = true;
            this.loadCodeBtn.Click += new System.EventHandler(this.loadCodeBtn_Click);
            // 
            // memoryDump
            // 
            this.memoryDump.Location = new System.Drawing.Point(649, 30);
            this.memoryDump.Name = "memoryDump";
            this.memoryDump.ReadOnly = true;
            this.memoryDump.Size = new System.Drawing.Size(494, 178);
            this.memoryDump.TabIndex = 9;
            this.memoryDump.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(649, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Memory dump";
            // 
            // accumulator
            // 
            this.accumulator.Location = new System.Drawing.Point(27, 44);
            this.accumulator.Name = "accumulator";
            this.accumulator.ReadOnly = true;
            this.accumulator.Size = new System.Drawing.Size(120, 22);
            this.accumulator.TabIndex = 11;
            this.accumulator.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
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
            this.groupBox1.Location = new System.Drawing.Point(649, 228);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(494, 150);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registers";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(345, 90);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Status";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(186, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Program Counter";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Stack Pointer";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(345, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Index Y";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(186, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Index  X";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Accumulator";
            // 
            // status
            // 
            this.status.Location = new System.Drawing.Point(346, 106);
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Size = new System.Drawing.Size(120, 22);
            this.status.TabIndex = 16;
            // 
            // programCounter
            // 
            this.programCounter.Location = new System.Drawing.Point(186, 106);
            this.programCounter.Name = "programCounter";
            this.programCounter.ReadOnly = true;
            this.programCounter.Size = new System.Drawing.Size(120, 22);
            this.programCounter.TabIndex = 15;
            // 
            // stackPointer
            // 
            this.stackPointer.Location = new System.Drawing.Point(27, 106);
            this.stackPointer.Name = "stackPointer";
            this.stackPointer.ReadOnly = true;
            this.stackPointer.Size = new System.Drawing.Size(120, 22);
            this.stackPointer.TabIndex = 14;
            // 
            // registerY
            // 
            this.registerY.Location = new System.Drawing.Point(346, 44);
            this.registerY.Name = "registerY";
            this.registerY.ReadOnly = true;
            this.registerY.Size = new System.Drawing.Size(120, 22);
            this.registerY.TabIndex = 13;
            // 
            // registerX
            // 
            this.registerX.Location = new System.Drawing.Point(186, 44);
            this.registerX.Name = "registerX";
            this.registerX.ReadOnly = true;
            this.registerX.Size = new System.Drawing.Size(120, 22);
            this.registerX.TabIndex = 12;
            this.registerX.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
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
            this.groupBox2.Location = new System.Drawing.Point(649, 399);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(494, 60);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Status Flags";
            // 
            // zeroFlag
            // 
            this.zeroFlag.AutoCheck = false;
            this.zeroFlag.AutoSize = true;
            this.zeroFlag.Location = new System.Drawing.Point(438, 31);
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
            this.overflowFlag.Location = new System.Drawing.Point(362, 31);
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
            this.breakFlag.Location = new System.Drawing.Point(301, 31);
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
            this.decimalFlag.Location = new System.Drawing.Point(228, 31);
            this.decimalFlag.Name = "decimalFlag";
            this.decimalFlag.Size = new System.Drawing.Size(67, 17);
            this.decimalFlag.TabIndex = 3;
            this.decimalFlag.Text = "Decimal";
            this.decimalFlag.UseVisualStyleBackColor = true;
            this.decimalFlag.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // interruptFlag
            // 
            this.interruptFlag.AutoCheck = false;
            this.interruptFlag.AutoSize = true;
            this.interruptFlag.Location = new System.Drawing.Point(150, 31);
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
            this.negativeFlag.Location = new System.Drawing.Point(71, 31);
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
            this.carryFlag.Location = new System.Drawing.Point(12, 31);
            this.carryFlag.Name = "carryFlag";
            this.carryFlag.Size = new System.Drawing.Size(53, 17);
            this.carryFlag.TabIndex = 0;
            this.carryFlag.Text = "Carry";
            this.carryFlag.UseVisualStyleBackColor = true;
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
            // SimulatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 477);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.memoryDump);
            this.Controls.Add(this.loadCodeBtn);
            this.Controls.Add(this.loadFromFileBtn);
            this.Controls.Add(this.resetBtn);
            this.Controls.Add(this.nextBtn);
            this.Controls.Add(this.runBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.operationsTable);
            this.Controls.Add(this.machineCodeText);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Name = "SimulatorForm";
            this.Text = "6502 Simulator";
            ((System.ComponentModel.ISupportInitialize)(this.operationsTable)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox machineCodeText;
        private System.Windows.Forms.DataGridView operationsTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button runBtn;
        private System.Windows.Forms.Button nextBtn;
        private System.Windows.Forms.Button resetBtn;
        private System.Windows.Forms.Button loadFromFileBtn;
        private System.Windows.Forms.Button loadCodeBtn;
        private System.Windows.Forms.RichTextBox memoryDump;
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
    }
}

