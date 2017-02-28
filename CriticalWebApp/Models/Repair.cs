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
        [Display(Name = "Repair Date")]
        public DateTime RepairDate { get; set; }
       
        [Required]
        [Display(Name = "In Serial Number")]
        public string  SerialNumber { get; set; }
        [Display(Name = "Out Serial Number")]
        public string OutSerialNumber { get; set; }
        [Required]
        [Display(Name = "Product In")]
        public string InProduct { get; set; }
        [Required]
        [Display(Name = "In Revision")]
        public string InProductRevision { get; set; }
        [Display(Name = "Product Out")]
        public string OutProduct { get; set; }
        [Display(Name = "Out Revision")]
        public string OutProductRevision { get; set; }
        [Display(Name = "Customer First Name")]
        public string CustomerFirstName { get; set; }
        [Display(Name = "Customer Last Name")]
        public string CustomerLastName { get; set; }
        [Display(Name = "Customer Complaint")]
        public string CustomerComplaint { get; set; }
        [Required]
        [Display(Name = "Issue Found")]
        public string IssueFound { get; set; }
        [Required]
        [Display(Name = "Action Taken")]
        public string ActionTaken { get; set; }
        public string RouterImagePath { get; set; }

    }
}