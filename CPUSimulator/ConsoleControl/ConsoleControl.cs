using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPUSimulator.ConsoleControl
{
    /// <summary>
    /// This console event handler is used for console events.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="args">The <see cref="ConsoleEventArgs"/> instance containing the event data.</param>
    public delegate void ConsoleEventHandler(object sender, ConsoleEventArgs args);

    /// <summary>
    /// A very simple Console control based on https://github.com/dwmkerr/consolecontrol
    /// </summary>
    public partial class ConsoleControl : UserControl
    {
        public ConsoleControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the KeyDown event of the richTextBoxConsole control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
        private void richTextBoxConsole_KeyDown(object sender, KeyEventArgs e)
        {
            //  If we're at the input point and it's backspace, bail
            if ((richTextBoxConsole.SelectionStart <= inputStart) && e.KeyCode == Keys.Back) e.SuppressKeyPress = true;

            //  Are we in the read-only zone?
            if (richTextBoxConsole.SelectionStart < inputStart)
            {
                //  Allow arrows and Ctrl-C.
                if (!(e.KeyCode == Keys.Left ||
                    e.KeyCode == Keys.Right ||
                    e.KeyCode == Keys.Up ||
                    e.KeyCode == Keys.Down ||
                    (e.KeyCode == Keys.C && e.Control)))
                {
                    e.SuppressKeyPress = true;
                }
            }

            // If it is return key, send only carriage return as input
            if (e.KeyCode == Keys.Return)
            {
                WriteInput(Convert.ToChar(0x0D).ToString(), Color.White);
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        /// <summary>
        /// Handles the KeyPress event of the richTextBoxConsole control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
        private void richTextBoxConsole_KeyPress(object sender, KeyPressEventArgs e)
        {
            WriteInput(e.KeyChar.ToString(), Color.White);
            e.Handled = true;
        }

        /// <summary>
        /// Writes the output to the Console control.
        /// </summary>
        /// <param name="output">The output.</param>
        /// <param name="color">The color.</param>
        public void WriteOutput(string output, Color color)
        {
            if (!this.IsHandleCreated)
                return;

            if (output == "\r")
                return;

            if (output == "\n")
                output = Environment.NewLine;

            Invoke((Action)(() =>
            {
                //  Write the output.
                richTextBoxConsole.SelectionColor = color;
                richTextBoxConsole.SelectedText += output;
                inputStart = richTextBoxConsole.SelectionStart;
            }));

            FireConsoleOutputEvent(output);
        }

        /// <summary>
        /// Clears the output.
        /// </summary>
        public void ClearOutput()
        {
            richTextBoxConsole.Clear();
            inputStart = 0;
        }

        /// <summary>
        /// Writes the input to the Console control.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="color">The color.</param>
        public void WriteInput(string input, Color color)
        {
            lastInput = input;
            FireConsoleInputEvent(input);
        }

        /// <summary>
        /// Fires the console output event.
        /// </summary>
        /// <param name="content">The content.</param>
        private void FireConsoleOutputEvent(string content)
        {
            //  Get the event.
            var theEvent = OnConsoleOutput;
            if (theEvent != null)
                theEvent(this, new ConsoleEventArgs(content));
        }

        /// <summary>
        /// Fires the console input event.
        /// </summary>
        /// <param name="content">The content.</param>
        private void FireConsoleInputEvent(string content)
        {
            //  Get the event.
            var theEvent = OnConsoleInput;
            if (theEvent != null)
                theEvent(this, new ConsoleEventArgs(content));
        }

        /// <summary>
        /// Current position that input starts at.
        /// </summary>
        int inputStart = -1;

        /// <summary>
        /// The is input enabled flag.
        /// </summary>
        private bool isInputEnabled = true;

        /// <summary>
        /// The last input string (used so that we can make sure we don't echo input twice).
        /// </summary>
        private string lastInput;

        /// <summary>
        /// Occurs when console output is produced.
        /// </summary>
        public event ConsoleEventHandler OnConsoleOutput;

        /// <summary>
        /// Occurs when console input is produced.
        /// </summary>
        public event ConsoleEventHandler OnConsoleInput;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is input enabled.
        /// </summary>
        /// <value>
        /// 	True if this instance is input enabled; otherwise, false.
        /// </value>
        [Category("Console Control"), Description("If true, the user can key in input.")]
        public bool IsInputEnabled
        {
            get { return isInputEnabled; }
            set
            {
                isInputEnabled = value;
                richTextBoxConsole.ReadOnly = !value;
            }
        }

        /// <summary>
        /// Gets the internal rich text box.
        /// </summary>
        [Browsable(false)]
        public RichTextBox InternalRichTextBox
        {
            get { return richTextBoxConsole; }
        }

        /// <summary>
        /// Gets or sets the font of the text displayed by the control.
        /// </summary>
        /// <returns>The <see cref="T:System.Drawing.Font" /> to apply to the text displayed by the control. The default is the value of the <see cref="P:System.Windows.Forms.Control.DefaultFont" /> property.</returns>
        ///   <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" />
        ///   <IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   </PermissionSet>
        public override Font Font
        {
            get
            {
                //  Return the base class font.
                return base.Font;
            }
            set
            {
                //  Set the base class font...
                base.Font = value;

                //  ...and the internal control font.
                richTextBoxConsole.Font = value;
            }
        }

        /// <summary>
        /// Gets or sets the background color for the control.
        /// </summary>
        /// <returns>A <see cref="T:System.Drawing.Color" /> that represents the background color of the control. The default is the value of the <see cref="P:System.Windows.Forms.Control.DefaultBackColor" /> property.</returns>
        ///   <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" />
        ///   </PermissionSet>
        public override Color BackColor
        {
            get
            {
                //  Return the base class background.
                return base.BackColor;
            }
            set
            {
                //  Set the base class background...
                base.BackColor = value;

                //  ...and the internal control background.
                richTextBoxConsole.BackColor = value;
            }
        }

    }
}
