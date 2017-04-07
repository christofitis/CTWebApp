using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CriticalWebApp.Models
{
    public class ProductReceived
    {
        public int Id { get; set; }
        public List<string> ProductsReceived { get; set; }
        public DateTime ReceivedDate { get; set; }
        public string Employee { get; set; }
        public int NumberOfBoxes { get; set; }
        public int QuantityOnBox { get; set; }
        public int CountedQuantity { get; set; }
        public string ReferenceNumber { get; set; }
        public string Notes { get; set; }

    }
}