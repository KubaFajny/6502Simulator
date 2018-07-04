using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator
{
    class RAM : Device
    {
        byte[] memory;

        public RAM(int size)
        {
            memory = new byte[size];
        }

        public void Write(int address, byte[] data)
        {
            data.CopyTo(memory, address);
        }

        public void Write(int address, byte data)
        {
            memory[address] = data;
        }

        public byte[] Read(int address, int length)
        {
            byte[] data = new byte[length];
            Array.Copy(memory, address, data, 0, length);
            return data;
        }

        public byte Read(int address)
        {
            return memory[address];
        }
    }
}
