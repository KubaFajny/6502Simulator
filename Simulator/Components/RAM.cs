using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    /// <summary>
    /// A simple device simulating an R/W memory via byte array with fixed size.
    /// Implements all neccessary methods for accessing the memory and uses a guard method to prevent manipulation with non-existing addresses.
    /// </summary>
    public class RAM : Device
    {
        byte[] memory;

        /// <summary>
        /// Constructs a new RAM instance with the specified initial size.
        /// </summary>
        /// <param name="size">The size of the memory.</param>
        public RAM(int size)
        {
            memory = new byte[size];
            DevType = DeviceType.RAM;
            Name = "RAM";
        }

        public override void Write(int address, byte[] data)
        {
            CheckAddress(address);
            data.CopyTo(memory, address);
        }

        public override void Write(int address, byte data)
        {
            CheckAddress(address);
            memory[address] = data;
        }

        public override byte[] Read(int address, int length)
        {
            CheckAddress(address);
            byte[] data = new byte[length];
            Array.Copy(memory, address, data, 0, length);
            return data;
        }

        public override byte Read(int address)
        {
            CheckAddress(address);
            return memory[address];
        }

        public override byte[] GetMemoryDump()
        {
            byte[] result = new byte[memory.Length];
            memory.CopyTo(result, 0);
            return result;
        }

        /// <summary>
        /// Checks if the given address is in the allowed range.
        /// </summary>
        /// <param name="address">The address in the memory to be checked.</param>
        private void CheckAddress(int address)
        {
            if (address < 0 || address >= memory.Length)
                throw new ArgumentOutOfRangeException("Target address");
        }
    }
}
