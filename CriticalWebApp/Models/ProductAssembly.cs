using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CriticalWebApp.Models
{
    public class ProductAssembly
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public Part Part { get; set; }
        public int PartId { get; set; }
        public int QuantityPerProduct { get; set; }
        public string LocationOnPcb { get; set; }

    }
}