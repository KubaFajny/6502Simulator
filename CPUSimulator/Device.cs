using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPUSimulator
{
    interface Device
    {
        void Write(int address, byte[] data);

        void Write(int address, byte data);

        byte[] Read(int address, int length);

        byte Read(int address);
    }
}
