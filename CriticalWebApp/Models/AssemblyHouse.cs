using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CriticalWebApp.Models
{
    public class AssemblyHouse
    {
        public int Id { get; set; }
        [Display(Name = "Assembly House")]
        [Required]
        public string Name { get; set; }
        public string Notes { get; set; }


    }
}