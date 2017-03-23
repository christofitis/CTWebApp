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
        public string Number { get; set; }

        public Product Product { get; set; }
        public int ProductId { get; set; }

        public string Customer { get; set; }


        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Required]
        public DateTime MFGDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ShipDate { get; set; }

        public string Notes { get; set; }


    }
}