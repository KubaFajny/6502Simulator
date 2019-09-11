using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator.ConsoleControl
{
    /// <summary>
    /// The ConsoleEventArgs are arguments for a console event.
    /// </summary>
    public class ConsoleEventArgs : EventArgs
    {
        /// <summary>
        /// Constructs an empty ConsoleEventArgs instance instance.
        /// </summary>
        public ConsoleEventArgs()
        {
        }

        /// <summary>
        /// Constructs a new ConsoleEventArgs instance with the specified content.
        /// </summary>
        /// <param name="content">The content.</param>
        public ConsoleEventArgs(string content)
        {
            Content = content;
        }

        /// <summary>
        /// Gets the content.
        /// </summary>
        public string Content
        {
            get;
            private set;
        }
    }
}
