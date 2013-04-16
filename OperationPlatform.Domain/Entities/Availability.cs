using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// add new references
using System.ComponentModel.DataAnnotations;

namespace OperationPlatform.Domain.Entities
{
    public class Availability
    {
        [Key]
        public int NodeID { get; set; }
        public string NodeName { get; set; }
        public string IPAddress { get; set; }
        public float AverangeAvailability { get; set; }
    }
}
