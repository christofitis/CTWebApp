using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CriticalWebApp.Models
{
    public class SerialNumber
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Serial #")]
        public string Number { get; set; }

        public Product Product { get; set; }
        public int ProductId { get; set; }
        [Display(Name = "Customer First Name")]
        public string CustomerFirstName { get; set; }
        [Display(Name = "Customer Last Name")]
        public string CustomerLastName { get; set; }



        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "MFG Date")]
        [Required]
        public DateTime MFGDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Shipment Date")]
        public DateTime? ShipDate { get; set; }

        public string Notes { get; set; }


    }
}