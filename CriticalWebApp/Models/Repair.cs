using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CriticalWebApp.Models
{
    public class Repair
    {
        public int Id { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime RepairDate { get; set; }
       
        [Required]
        public string  SerialNumber { get; set; }
        public string OutSerialNumber { get; set; }
        [Required]
        public string InProduct { get; set; }
        [Required]
        public string InProductRevision { get; set; }
        public string OutProduct { get; set; }
        public string OutProductRevision { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerComplaint { get; set; }
        [Required]
        public string IssueFound { get; set; }
        [Required]
        public string ActionTaken { get; set; }
        public string RouterImagePath { get; set; }

    }
}