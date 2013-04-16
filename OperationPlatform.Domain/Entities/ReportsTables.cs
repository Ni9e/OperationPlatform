using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// add new ferences
using System.ComponentModel.DataAnnotations;

namespace OperationPlatform.Domain.Entities
{
    public class MemoryUsed
    {
        [Key]
        public int NodeID { get; set; }
        public string NodeName { get; set; }
        public float AvgMemoryUsed { get; set; }
        public float MaxMemoryUsed { get; set; }
        public float TotalMemory { get; set; }
        public float AvgPercentMemoryUsed { get; set; }
        public DateTime DateTime { get; set; }
    }

    public class Availability
    {
        [Key]
        public int NodeID { get; set; }
        public string NodeName { get; set; }
        public string IPAddress { get; set; }
        public float AverangeAvailability { get; set; }
        public DateTime DateTime { get; set; }
    }    

    public class CPUUsed
    {
        [Key]
        public int NodeID { get; set; }
        public string NodeName { get; set; }
        public float AverengeCPULoad { get; set; }
        public float PeakCPULoad { get; set; }
        public DateTime DateTime { get; set; }
    }

    public class DeviceNetwork
    {
        [Key]
        public int NodeID { get; set; }
        public string NodeName { get; set; }
        public string Interface { get; set; }
        public float AvgReceive { get; set; }
        public float MaxReceive { get; set; }
        public float AvgTrans { get; set; }
        public float MaxTrans { get; set; }
        public DateTime DateTime { get; set; }
    }

    public class DeviceDiskUsed
    {
        [Key]
        public int NodeID { get; set; }
        public string NodeName { get; set; }
        public string Volume { get; set; }
        public float DiskSize { get; set; }
        public float DiskSpaceUsed { get; set; }
        public float PercentDiskSpaceUsed { get; set; }
        public DateTime DateTime { get; set; }
    }
}
