using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// add new references
using OperationPlatform.Domain.Entities;
using System.Data.SqlClient;

namespace OperationPlatform.Domain.Abstract
{
    public interface IReports
    {
        IEnumerable<MemoryUsed> MemoryUseds { get; }
        IEnumerable<CPUUsed> CPUUseds { get; }
        IEnumerable<Availability> Availabilitys { get; }
        IEnumerable<DeviceNetwork> DeviceNetworks { get; }
        IEnumerable<DeviceDiskUsed> DeviceDiskUseds { get; }

        IEnumerable<MemoryUsed> GetMemoryUseds(string sql, SqlParameter[] parms);
        IEnumerable<CPUUsed> GetCPUUseds(string sql, SqlParameter[] parms);
        IEnumerable<Availability> GetAvailabilitys(string sql, SqlParameter[] parms);
        IEnumerable<DeviceNetwork> GetDeviceNetworks(string sql, SqlParameter[] parms);
        IEnumerable<DeviceDiskUsed> GetDeviceDiskUseds(string sql, SqlParameter[] parms);
    }
}
