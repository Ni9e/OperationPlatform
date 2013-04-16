using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// add new references
using System.ComponentModel.DataAnnotations;

namespace OperationPlatform.Domain.Entities
{
    public class DeviceNetwork
    {
        [Key]
        public int NodeID { get; set; }
        public string Interface { get; set; }
        public string AvgReceive { get; set; }
    }
}
