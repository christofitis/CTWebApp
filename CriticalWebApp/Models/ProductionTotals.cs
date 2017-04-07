using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CriticalWebApp.Models
{
    public class ProductionTotals
    {

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Product { get; set; }
        public int QtyNeeded { get; set; }
        public int QtyInShipping { get; set; }

    }
}