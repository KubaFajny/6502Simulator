using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    /// <summary>
    /// A simple device simulating a read-only memory via byte array with fixed size.
    /// Implements only read methods for access and uses a guard method to prevent manipulation with non-existing addresses.
    /// </summary>
    public class ROM : Device
    {
        byte[] memory;

        /// <summary>
        /// Constructs a new ROM instance with the specified initial size. The instance is filled with the specified content.
        /// </summary>
        /// <param name="size">The size of the memory.</param>
        /// <param name="data">The byte array of ROM data, it's size must be equal to the size of the whole ROM memory. Otherwise an exception is thrown.</param>
        /// <param name="name">The optional device name parameter, implicitly "ROM"</param>
        public ROM(int size, byte[] data, string name = "ROM")
        {
            if (size != data.Length)
                throw new ArgumentException("ROM data size must be equal to the specified ROM size.");

            memory = new byte[size];
            DevType = DeviceType.ROM;
            Name = name;
            data.CopyTo(memory, 0);
        }

        public override void Write(int address, byte[] data)
        {
            throw new InvalidOperationException("Cannot write at the read-only memory address.");
        }

        public override void Write(int address, byte data)
        {
            throw new InvalidOperationException("Cannot write at the read-only memory address.");
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
