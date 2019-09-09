using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RangeTree;

namespace CPUSimulator
{
    /// <summary>
    /// This class is used in the RangeTree representing memory mapping of devices in the simulated computer.
    /// Each device is mapped on some memory range with the start and the end address, overlapping the RAM at these ranges.
    /// Access to such addresses will be redirected to this device instead of the RAM. If no device is mapped at the target address, the RAM is accessed.
    /// </summary>
    public class DeviceMemoryRange : IRangeProvider<int>
    {
        public Range<int> Range { get; set; }

        public Device Device { get; set; }
    }

    /// <summary>
    /// This class implements the IComparer interface. 
    /// It is used to compare two ranges.
    /// </summary>
    public class DeviceMemoryRangeComparer : IComparer<DeviceMemoryRange>
    {
        public int Compare(DeviceMemoryRange x, DeviceMemoryRange y)
        {
            return x.Range.CompareTo(y.Range);
        }
    }
}
