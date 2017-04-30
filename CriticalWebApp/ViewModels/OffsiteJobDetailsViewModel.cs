using CriticalWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CriticalWebApp.ViewModels
{
    public class OffsiteJobDetailsViewModel
    {
        public IEnumerable<JobInventory> JobInventories { get; set; }
        public OffsiteJob OffsiteJob { get; set; }
        public IEnumerable<ProductAssembly> ProductAssemblies { get; set; }

    }
}