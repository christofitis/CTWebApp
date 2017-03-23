using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CriticalWebApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string SKU { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string HardwareRevision { get; set; }
        public string SoftwareRevision { get; set; }
        [Required]
        public string SerialNumberPrefix { get; set; }

        public string Notes { get; set; }

    }
}