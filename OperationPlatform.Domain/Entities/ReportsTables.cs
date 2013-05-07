using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// add new ferences
using System.ComponentModel.DataAnnotations;

namespace OperationPlatform.Domain.Entities
{

    #region Device
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

    #endregion

    #region Application

    public class ApplicationAvailability
    {
        [Key]
        public int NodeID { get; set; }
        public string NodeName { get; set; }
        public string ApplicationName { get; set; }
        public float AverangeApplicationAvailability { get; set; }
        public DateTime DateTime { get; set; }
    }

    public class ApplicationCPUUsed
    {
        [Key]
        public int NodeID { get; set; }
        public string NodeName { get; set; }
        public string ApplicationName { get; set; }
        public string ComponentName { get; set; }
        public float AveragePercentCPU { get; set; }
        public float PeakPercentCPU { get; set; }
        public DateTime DateTime { get; set; }
    }

    public class ApplicationMemoryUsed
    {
        [Key]
        public int NodeID { get; set; }
        public string NodeName { get; set; }
        public string ApplicationName { get; set; }
        public string ComponentName { get; set; }
        public float AveragePercentMemory { get; set; }
        public float PeakPercentMemory { get; set; }
        public DateTime DateTime { get; set; }
    }

    public class ApplicationCurrentStatus
    {
        [Key]
        public int NodeID { get; set; }
        public string NodeName { get; set; }
        public string ApplicationName { get; set; }
        public string ApplicationStatus { get; set; }
        public string ComponentName { get; set; }
        public string CompinentStatus { get; set; }        
    }

    #endregion
}
