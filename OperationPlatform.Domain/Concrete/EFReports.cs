using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// add new references
using OperationPlatform.Domain.Abstract;
using OperationPlatform.Domain.Entities;
using System.Data.SqlClient;

namespace OperationPlatform.Domain.Concrete
{
    public class EFReports : IReports
    {
        private EFDbContext db = new EFDbContext();

        #region StoreProcudure

        public IEnumerable<MemoryUsed> GetMemoryUseds(string sql, SqlParameter[] parms)
        {
            return (from p in db.Database.SqlQuery<MemoryUsed>(sql, parms)
                    select p);
        }

        public IEnumerable<CPUUsed> GetCPUUseds(string sql, SqlParameter[] parms)
        {
            return (from p in db.Database.SqlQuery<CPUUsed>(sql, parms)
                    select p);
        }

        public IEnumerable<Availability> GetAvailabilitys(string sql, SqlParameter[] parms)
        {
            return (from p in db.Database.SqlQuery<Availability>(sql, parms)
                    select p);
        }

        public IEnumerable<DeviceNetwork> GetDeviceNetworks(string sql, SqlParameter[] parms)
        {
            return (from p in db.Database.SqlQuery<DeviceNetwork>(sql, parms)
                    select p);
        }

        public IEnumerable<DeviceDiskUsed> GetDeviceDiskUseds(string sql, SqlParameter[] parms)
        {
            return (from p in db.Database.SqlQuery<DeviceDiskUsed>(sql, parms)
                    select p);
        }

        #endregion

        #region Tables
        public IEnumerable<MemoryUsed> MemoryUseds
        {
            get { return db.MemoryUseds; }
        }

        public IEnumerable<CPUUsed> CPUUseds
        {
            get { return db.CPUUseds; }
        }

        public IEnumerable<Availability> Availabilitys
        {
            get { return db.Availabilitys; }
        }

        public IEnumerable<DeviceNetwork> DeviceNetworks
        {
            get { return db.DeviceNetworks; }
        }

        public IEnumerable<DeviceDiskUsed> DeviceDiskUseds
        {
            get { return db.DeviceDiskUseds; }
        }

        #endregion
    }
}
