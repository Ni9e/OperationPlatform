using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// add new references
using System.ComponentModel.DataAnnotations;

namespace OperationPlatform.Domain.Entities
{
    public class CPUUsed
    {
        [Key]
        public int NodeID { get; set; }
        public string NodeName { get; set; }
        public float AverengeCPULoad { get; set; }
        public float PeakCPULoad { get; set; }        
    }
}
