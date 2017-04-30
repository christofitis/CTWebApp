using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CriticalWebApp.Models
{
    public class Part
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MFGNumber { get; set; }
        public string Description { get; set; }
        public int? QuantityOnHand { get; set; }
        public string Category { get; set; }





    }
}