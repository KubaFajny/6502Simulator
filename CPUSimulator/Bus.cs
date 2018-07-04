using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator
{
    enum DeviceType { RAM }

    class Bus
    {
        Dictionary<DeviceType, Device> devices;

        const int MEMORY_SIZE = 0x10000; // 64 kB

        public Bus()
        {
            devices = new Dictionary<DeviceType, Device>();
            devices.Add(DeviceType.RAM, new RAM(MEMORY_SIZE));
        }

        public void WriteToMemory(int address, byte[] data)
        {
            if (address < 0 || address >= MEMORY_SIZE)
                throw new ArgumentOutOfRangeException("Target address is out of range.");

            devices[DeviceType.RAM].Write(address, data);
        }

        public void WriteToMemory(int address, byte data)
        {
            if (address < 0 || address >= MEMORY_SIZE)
                throw new ArgumentOutOfRangeException("Target address is out of range.");

            devices[DeviceType.RAM].Write(address, data);
        }

        public byte[] ReadFromMemory(int address, int length)
        {
            if (address < 0 || address >= MEMORY_SIZE)
                throw new ArgumentOutOfRangeException("Target address is out of range.");

            return devices[DeviceType.RAM].Read(address, length);
        }

        public byte ReadFromMemory(int address)
        {
            if (address < 0 || address >= MEMORY_SIZE)
                throw new ArgumentOutOfRangeException("Target address is out of range.");

            return devices[DeviceType.RAM].Read(address);
        }

        public String GetMemoryDump()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("-------- ZERO PAGE -------------------------------------------------------------------------------------------");
            byte[] zeroPage = ReadFromMemory(0, 0x100);
            sb.AppendLine(BitConverter.ToString(zeroPage).Replace("-", " "));

            sb.AppendLine();
            sb.AppendLine("-------- STACK -----------------------------------------------------------------------------------------------");
            byte[] stack = ReadFromMemory(0x100, 0x100);
            sb.AppendLine(BitConverter.ToString(stack).Replace("-", " "));

            sb.AppendLine();
            sb.AppendLine("-------- FREE MEMORY -----------------------------------------------------------------------------------------");
            byte[] mem = ReadFromMemory(0x200, MEMORY_SIZE - 0x200);
            sb.AppendLine(BitConverter.ToString(mem).Replace("-", " "));

            return sb.ToString();
        }
    }
}
