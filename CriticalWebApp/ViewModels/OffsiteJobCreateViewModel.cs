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
        public IEnumerable<AssemblyHouse> AssemblyHouses { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public OffsiteJob OffsiteJob { get; set; }
    }
}