using CriticalWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CriticalWebApp.ViewModels
{
    public class ProductionOutputTotalsViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<ProductionOutputTotals> ProductionOutputTotals { get; set; }
        public List<ProductionAverageTotals> ProductionAverageTotals { get; set; }
    }



}