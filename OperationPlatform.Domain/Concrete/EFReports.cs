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

        public IEnumerable<ApplicationAvailability> GetApplicationAvailability(string sql, SqlParameter[] parms)
        {
            return (from p in db.Database.SqlQuery<ApplicationAvailability>(sql, parms)
                    select p);
        }

        public IEnumerable<ApplicationCPUUsed> GetApplicationCPUUsed(string sql, SqlParameter[] parms)
        {
            return (from p in db.Database.SqlQuery<ApplicationCPUUsed>(sql, parms)
                    select p);
        }

        public IEnumerable<ApplicationMemoryUsed> GetApplicationMemoryUsed(string sql, SqlParameter[] parms)
        {
            return (from p in db.Database.SqlQuery<ApplicationMemoryUsed>(sql, parms)
                    select p);
        }

        public IEnumerable<ApplicationCurrentStatus> GetApplicationCurrentStatus(string sql, SqlParameter[] parms)
        {
            return (from p in db.Database.SqlQuery<ApplicationCurrentStatus>(sql, parms)
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

        public IEnumerable<ApplicationAvailability> ApplicationAvailability
        {
            get { return db.ApplicationAvailability; }
        }

        public IEnumerable<ApplicationCPUUsed> ApplicationCPUUsed
        {
            get { return db.ApplicationCPUUseds; }
        }

        public IEnumerable<ApplicationMemoryUsed> ApplicationMemoryUsed
        {
            get { return db.ApplicationMemoryUseds; }
        }

        public IEnumerable<ApplicationCurrentStatus> ApplicationCurrentStatus
        {
            get { return db.ApplicationCurrentStatus; }
        }

        #endregion
    }
}
