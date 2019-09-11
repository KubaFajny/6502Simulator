using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public enum DeviceType { RAM, ROM, ACIA }

    /// <summary>
    /// This abstract class is the superclass of all classes representing a simulated device used in the computer.
    /// Each device is identified by its name and device type. Also, each device needs to implement its own R/W access methods.
    /// The device has an ability to request the CPU interrupt by firing the InterruptRequestEvent.
    /// </summary>
    public abstract class Device
    {
        public DeviceType DevType { get; protected set; }

        public event Action InterruptRequestEvent;

        public string Name { get; protected set; }

        public abstract void Write(int address, byte[] data);

        public abstract void Write(int address, byte data);

        public abstract byte[] Read(int address, int length);

        public abstract byte Read(int address);

        public abstract byte[] GetMemoryDump();

        public void FireInterruptRequestEvent()
        {
            InterruptRequestEvent();
        }
    }
}
