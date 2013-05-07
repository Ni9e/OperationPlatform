using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
// add new references
using OperationPlatform.Domain.Entities;
using OperationPlatform.Domain.Concrete;
using OperationPlatform.Domain.Abstract;
using System.Collections;
using System.Data.Objects.SqlClient;
using System.Reflection;
using System.Data.SqlClient;

namespace OperationPlatform.WebUI.Controllers
{
    [Authorize(Roles = "Reports")]
    public class ReportsController : Controller
    {
        private string[] paramNames = { "datetime" };
        private IReports reports;

        public ReportsController(IReports repo)
        {
            reports = repo;
        }

        public ViewResult Index()
        {
            return View();
        }

        //parmNames.Length must equal parm.Length
        private SqlParameter[] InitialParams(string[] parmNames, params string[] parm)
        {
            SqlParameter[] parms = new SqlParameter[parmNames.Length];
            try
            {
                for (int i = 0; i < parmNames.Length; i++)
                {
                    parms[i] = new SqlParameter(parmNames[i], parm[i]);
                }                    
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return parms;
        }

        #region Device

        [HttpPost]
        public ActionResult GetMemoryUsedInformation(string datetime = "")
        {
            var result = reports.GetMemoryUseds("exec GetMemoryUsed @datetime", InitialParams(paramNames, datetime));

            var jqData = (from m in result
                          select new
                          {
                              id = m.NodeID,
                              cell = new object[]
                            {
                                m.NodeName.Trim(),
                                m.AvgMemoryUsed < 1000 ? Math.Round(m.AvgMemoryUsed,1).ToString() + " Mbytes" : Math.Round((m.AvgMemoryUsed / 1024),1).ToString() + " Gbytes",
                                m.MaxMemoryUsed < 1000 ? Math.Round(m.MaxMemoryUsed,1).ToString() + " Mbytes" : Math.Round((m.MaxMemoryUsed / 1024),1).ToString() + " Gbytes",
                                m.TotalMemory < 1000 ? Math.Round(m.TotalMemory,1).ToString() + " Mbytes" : Math.Round((m.TotalMemory / 1024),1).ToString() + " Gbytes",
                                Math.Round(m.AvgPercentMemoryUsed,2).ToString() + "%"
                            }

                          }).ToArray();
            var jsonData = new { rows = jqData };
            return Json(jsonData);

        }
                
        [HttpPost]
        public ActionResult GetAvailability(string datetime = "")
        {
            var result = reports.GetAvailabilitys("exec GetAvailability @datetime", InitialParams(paramNames, datetime));

            var jqData = (from m in result
                          select new
                          {
                              id = m.NodeID,
                              cell = new object[]
                            {
                                m.NodeName.Trim(),
                                m.IPAddress.Trim(),
                                Math.Round(m.AverangeAvailability,2).ToString() + "%"                                
                            }

                          }).ToArray();
            var jsonData = new { rows = jqData };
            return Json(jsonData);
        }
                
        [HttpPost]
        public ActionResult GetCPUUsed(string datetime="")
        {
            var result = reports.GetCPUUseds("exec GetCPUUsed @datetime", InitialParams(paramNames, datetime));

            var jqData = (from m in result
                          select new
                          {
                              id = m.NodeID,
                              cell = new object[]
                            {
                                m.NodeName.Trim(),
                                m.AverengeCPULoad.ToString() + "%",
                                m.PeakCPULoad.ToString() + "%"                                
                            }

                          }).ToArray();
            var jsonData = new { rows = jqData };
            return Json(jsonData);
        }
                
        [HttpPost]
        public ActionResult GetDeviceNetwork(string datetime = "")
        {
            var result = reports.GetDeviceNetworks("exec GetDeviceNetwork @datetime", InitialParams(paramNames, datetime));

            var jqData = (from m in result
                          select new
                          {
                              id = m.NodeID,
                              cell = new object[]
                            {
                                m.NodeName.Trim(),
                                m.Interface.Trim(),
                                m.AvgReceive <= 1000 ? Math.Round(m.AvgReceive,1).ToString()+" bps" : 
                                                      (m.AvgReceive >1000 && m.AvgReceive <=1000000 ? 
                                                      Math.Round((m.AvgReceive/1024),1).ToString()+" Kbps" : Math.Round((m.AvgReceive/1048576),1).ToString()+" Mbps"),
                                m.MaxReceive <= 1000 ? Math.Round(m.MaxReceive,1).ToString()+" bps" : 
                                                      (m.MaxReceive >1000 && m.MaxReceive <=1000000 ? 
                                                      Math.Round((m.MaxReceive/1024),1).ToString()+" Kbps" : Math.Round((m.MaxReceive/1048576),1).ToString()+" Mbps"),
                                m.AvgTrans <= 1000 ? Math.Round(m.AvgTrans,1).ToString()+" bps" : 
                                                      (m.AvgTrans >1000 && m.AvgTrans <=1000000 ? 
                                                      Math.Round((m.AvgTrans/1024),1).ToString()+" Kbps" : Math.Round((m.AvgTrans/1048576),1).ToString()+" Mbps"),
                                m.MaxTrans <= 1000 ? Math.Round(m.MaxTrans,1).ToString()+" bps" : 
                                                      (m.MaxTrans >1000 && m.MaxTrans <=1000000 ? 
                                                      Math.Round((m.MaxTrans/1024),1).ToString()+" Kbps" : Math.Round((m.MaxTrans/1048576),1).ToString()+" Mbps")
                            }

                          }).ToArray();
            var jsonData = new { rows = jqData };
            return Json(jsonData);
        }

        [HttpPost]
        public ActionResult GetDeviceDiskUsed(string datetime = "")
        {
            var result = reports.GetDeviceDiskUseds("exec GetDeviceDiskUsed @datetime", InitialParams(paramNames, datetime));

            var jqData = (from m in result
                          select new
                          {
                              id = m.NodeID,
                              cell = new object[]
                            {
                                m.NodeName.Trim(),
                                m.Volume.Trim(),
                                m.DiskSize < 1000 ? Math.Round(m.DiskSize,1).ToString()+" MB" : Math.Round((m.DiskSize / 1024), 1).ToString()+" GB",
                                m.DiskSpaceUsed < 1000 ? Math.Round(m.DiskSpaceUsed,1).ToString()+" MB" : Math.Round((m.DiskSpaceUsed / 1024), 1).ToString() +" GB",
                                m.PercentDiskSpaceUsed.ToString() + "%"                               
                            }

                          }).ToArray();
            var jsonData = new { rows = jqData };
            return Json(jsonData);
        }        

        public PartialViewResult DeviceReports()
        {
            return PartialView();
        }

        #endregion

        #region Application

        [HttpPost]
        public ActionResult GetApplicationAvailability(string datetime = "")
        {
            var result = reports.GetApplicationAvailability("exec GetApplicationAvailability @datetime", InitialParams(paramNames, datetime));

            var jqData = (from m in result
                          select new
                          {
                              id = m.NodeID,
                              cell = new object[]
                            {
                                m.NodeName.Trim(),
                                m.ApplicationName.Trim(),
                                Math.Round(m.AverangeApplicationAvailability,2).ToString() + "%"                                
                            }

                          }).ToArray();
            var jsonData = new { rows = jqData };
            return Json(jsonData);
            
        }

        [HttpPost]
        public ActionResult GetApplicationCPUUsed(string datetime = "")
        {
            var result = reports.GetApplicationCPUUsed("exec GetApplicationCPUUsed @datetime", InitialParams(paramNames, datetime));

            var jqData = (from m in result
                          select new
                          {
                              id = m.NodeID,
                              cell = new object[]
                            {
                                m.NodeName.Trim(),
                                m.ApplicationName.Trim(),
                                m.ComponentName.Trim(),
                                Math.Round(m.AveragePercentCPU,2).ToString() + "%",
                                Math.Round(m.PeakPercentCPU,2).ToString() + "%"
                            }

                          }).ToArray();
            var jsonData = new { rows = jqData };
            return Json(jsonData);

        }

        [HttpPost]
        public ActionResult GetApplicationMemoryUsed(string datetime = "")
        {
            var result = reports.GetApplicationMemoryUsed("exec GetApplicationMemoryUsed @datetime", InitialParams(paramNames, datetime));

            var jqData = (from m in result
                          select new
                          {
                              id = m.NodeID,
                              cell = new object[]
                            {
                                m.NodeName.Trim(),
                                m.ApplicationName.Trim(),
                                m.ComponentName.Trim(),
                                Math.Round(m.AveragePercentMemory,2).ToString() + "%",
                                Math.Round(m.PeakPercentMemory,2).ToString() + "%"
                            }

                          }).ToArray();
            var jsonData = new { rows = jqData };
            return Json(jsonData);

        }

        [HttpPost]
        public ActionResult GetApplicationCurrentStatus(string datetime = "")
        {
            var result = reports.GetApplicationCurrentStatus("exec GetApplicationCurrentStatus @datetime", InitialParams(paramNames, datetime));

            var jqData = (from m in result
                          select new
                          {
                              id = m.NodeID,
                              cell = new object[]
                            {
                                m.NodeName.Trim(),
                                m.ApplicationName.Trim(),
                                m.ApplicationStatus.Trim(),
                                m.ComponentName.Trim(), 
                                m.CompinentStatus.Trim()
                            }

                          }).ToArray();
            var jsonData = new { rows = jqData };
            return Json(jsonData);

        }

        public ViewResult ApplicationReports()
        {
            return View();
        }

        #endregion
    }
}
