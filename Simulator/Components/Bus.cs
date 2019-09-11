using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RangeTree;

namespace Simulator
{
    /// <summary>
    /// Connects all the simulated computer's components together. The CPU reads (writes) data from (to) other devices.
    /// Each device is memory mapped and has an ability to request the interruption of the CPU.
    /// The Bus has also methods for manipulating with the Stack, sending input or receiving output via IO device and dumping the memory of each device.
    /// </summary>
    public class Bus
    {
        RangeTree<int, DeviceMemoryRange> deviceMemoryMap;
        Dictionary<DeviceType, List<Device>> deviceMap;
        CPU cpu;

        /// <summary>
        /// Constructs a new Bus instance.
        /// </summary>
        public Bus()
        {
            deviceMemoryMap = new RangeTree<int, DeviceMemoryRange>(new DeviceMemoryRangeComparer());
            deviceMap = new Dictionary<DeviceType, List<Device>>();
        }

        /// <summary>
        /// Adds the CPU to this Bus.
        /// </summary>
        /// <param name="cpu">The CPU instance.</param>
        public void AddCPU(CPU cpu)
        {
            this.cpu = cpu;
        }

        /// <summary>
        /// Adds a new device to this Bus, maps it onto the memory and sets up an listener for the interrupt request.
        /// </summary>
        /// <param name="device">The device to be added.</param>
        /// <param name="startAddress">The starting address of the device memory mapping.</param>
        /// <param name="endAddress">The ending address of the device memory mapping.</param>
        public void AddDevice(Device device, int startAddress, int endAddress)
        {
            // There cannot be two devices (other than RAM) mapped on the same address range
            List<DeviceMemoryRange> deviceMemoryRanges = deviceMemoryMap.Query(new Range<int>(startAddress, endAddress)).FindAll(devMemoryRange => devMemoryRange.Device.DevType != DeviceType.RAM);
            if (deviceMemoryRanges.Count > 0)
                throw new ArgumentException("Another device is already mapped at the target address range.");

            // Create a new device memory range for this device
            deviceMemoryMap.Add(new DeviceMemoryRange() { Device = device, Range = new Range<int>(startAddress, endAddress) });
            if (deviceMap.ContainsKey(device.DevType))
                deviceMap[device.DevType].Add(device);
            else
                deviceMap[device.DevType] = new List<Device>() { device };

            device.InterruptRequestEvent += new Action(cpu.InvokeIRQ);
        }

        /// <summary>
        /// Writes an array of bytes at the specified address.
        /// </summary>
        /// <param name="address">The address where to start writing the data.</param>
        /// <param name="data">The array of bytes to write.</param>
        public void Write(int address, byte[] data)
        {
            DeviceMemoryRange deviceMemoryRange = GetDeviceMemoryRangeByAddress(address);
            int deviceAddress = CalculateDeviceAddress(deviceMemoryRange, address);
            deviceMemoryRange.Device.Write(deviceAddress, data);
        }

        /// <summary>
        /// Writes a single byte at the specified address.
        /// </summary>
        /// <param name="address">The address where to start writing the data.</param>
        /// <param name="data">The single byte to write.</param>
        public void Write(int address, byte data)
        {
            DeviceMemoryRange deviceMemoryRange = GetDeviceMemoryRangeByAddress(address);
            int deviceAddress = CalculateDeviceAddress(deviceMemoryRange, address);
            deviceMemoryRange.Device.Write(deviceAddress, data);
        }

        /// <summary>
        /// Reads an array of bytes from the specified address.
        /// </summary>
        /// <param name="address">The address where to start reading the data.</param>
        /// <param name="length">The number of bytes to be read.</param>
        public byte[] Read(int address, int length)
        {
            DeviceMemoryRange deviceMemoryRange = GetDeviceMemoryRangeByAddress(address);
            int deviceAddress = CalculateDeviceAddress(deviceMemoryRange, address);
            return deviceMemoryRange.Device.Read(deviceAddress, length);
        }

        /// <summary>
        /// Reads a single byte from the specified address.
        /// </summary>
        /// <param name="address">The address where to start reading the data.</param>
        public byte Read(int address)
        {
            DeviceMemoryRange deviceMemoryRange = GetDeviceMemoryRangeByAddress(address);
            int deviceAddress = CalculateDeviceAddress(deviceMemoryRange, address);
            return deviceMemoryRange.Device.Read(deviceAddress);
        }

        /// <summary>
        /// Pushes a single byte on the Stack and decrements the Stack Pointer by one.
        /// </summary>
        /// <param name="state">The CPUState instance containing register values.</param>
        /// <param name="data">The single byte to be pushed on the Stack.</param>
        public void StackPush(CPUState state, byte data)
        {
            Write(Simulator.STACK_ADDRESS + state.SP, data);
            state.SP--;
        }

        /// <summary>
        /// Increments the Stack Pointer by one and pops a single byte from the Stack.
        /// </summary>
        /// <param name="state">The CPUState instance containing register values.</param>
        public byte StackPop(CPUState state)
        {
            state.SP++;
            return Read(Simulator.STACK_ADDRESS + state.SP);
        }

        /// <summary>
        /// Gets an output char from the IO device.
        /// </summary>
        /// <returns>The single byte representing the output char if an I/O device is mapped, otherwise null.</returns>
        public byte? GetConsoleOutput()
        {
            Device device = deviceMap[DeviceType.ACIA]?.First();
            if (device == null)
                return null;

            return ((ACIA)device).GetTxData();
        }

        /// <summary>
        /// Sends an input char to the IO device.
        /// </summary>
        /// <param name="data">The single byte representing the input char.</param>
        public void SendConsoleInput(byte data)
        {
            foreach (DeviceMemoryRange devMemoryRange in deviceMemoryMap.Items)
                if (devMemoryRange.Device.DevType == DeviceType.ACIA)
                    ((ACIA)devMemoryRange.Device).SetRxData(data);
        }

        /// <summary>
        /// Dumps the memory of each device connected to this Bus.
        /// </summary>
        /// <returns>The dictionary of memory dumps, where the key is device name and value is an byte array.</returns>
        public Dictionary<string, byte[]> DumpDevicesMemory()
        {
            Dictionary<string, byte[]> devicesMemory = new Dictionary<string, byte[]>();
            foreach (DeviceMemoryRange devMemoryRange in deviceMemoryMap.Items)
                devicesMemory[devMemoryRange.Device.Name] = devMemoryRange.Device.GetMemoryDump();

            return devicesMemory;
        }

        /// <summary>
        /// Finds a device that is mapped on the memory range containing the given address.
        /// </summary>
        /// <param name="address">The address in the memory.</param>
        /// <returns>The <see cref="DeviceMemoryRange"/> instance containing the device and the memory range on which that device is mapped.</returns>
        private DeviceMemoryRange GetDeviceMemoryRangeByAddress(int address)
        {
            List<DeviceMemoryRange> deviceMemoryRanges = deviceMemoryMap.Query(address);
            if (deviceMemoryRanges.Count > 1)
                deviceMemoryRanges = deviceMemoryRanges.FindAll(devMemoryRange => devMemoryRange.Device.DevType != DeviceType.RAM);
            else if (deviceMemoryRanges.Count == 0)
                throw new ArgumentException("No device is mapped at the target address.");

            return deviceMemoryRanges.First();
        }

        /// <summary>
        /// Calculates the relative device address from the specified device mapping and the specified absolute address.
        /// </summary>
        /// <param name="deviceMemoryRange">The memory mapping of the device.</param>
        /// <param name="address">The absolute address to be converted to an device address.</param>
        /// <returns>The relative device address.</returns>
        private int CalculateDeviceAddress(DeviceMemoryRange deviceMemoryRange, int address)
        {
            return address - deviceMemoryRange.Range.From;
        }
    }
}
