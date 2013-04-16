using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// add new references
using System.ComponentModel.DataAnnotations;

namespace OperationPlatform.WebUI.Models
{
    public class LogOnViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}