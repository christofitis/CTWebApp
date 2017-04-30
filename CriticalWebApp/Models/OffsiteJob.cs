using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CriticalWebApp.Models
{
    public class OffsiteJob
    {
        public int Id { get; set; }

        public string PONumber { get; set; }

        public AssemblyHouse AssemblyHouse { get; set; }
        public int AssemblyHouseId { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public int JobQuantity { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime IssuedDate { get; set; }
        public int QuantityOfProductDelivered { get; set; }



    }
}