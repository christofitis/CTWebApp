using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CriticalWebApp.Models
{
    public class JobInventory
    {
        public int Id { get; set; }
        public Part Part { get; set; }
        public int PartId { get; set; }
        public OffsiteJob OffsiteJob { get; set; }
        public int OffsiteJobId { get; set; }
        public int QuantityAtJobSite { get; set; }

    }
}