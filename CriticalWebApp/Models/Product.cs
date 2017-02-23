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
        public string Name { get; set; }
        [Required]
        public string Revision { get; set; }
        public string Notes { get; set; }
        public string SerialNumberPrefix { get; set; }
    }
}