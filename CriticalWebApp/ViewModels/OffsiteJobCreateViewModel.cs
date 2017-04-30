using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CriticalWebApp.ViewModels;
using CriticalWebApp.Models;

namespace CriticalWebApp.ViewModels
{
    public class OffsiteJobCreateViewModel
    {
        public List<string> AssemblyHouses { get; set; }
        public List<string> Products { get; set; }
        public OffsiteJob OffsiteJob { get; set; }
        public List<ProductAssembly> ProductAssemblies { get; set; }
        public IEnumerable<Product> AllProducts { get; set; }

        public OffsiteJobCreateViewModel()
        {
            AssemblyHouses = new List<string>();
            Products = new List<string>();
        }
        
    }
}