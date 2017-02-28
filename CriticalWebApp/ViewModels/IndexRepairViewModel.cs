using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CriticalWebApp.Models;

namespace CriticalWebApp.ViewModels
{
    public class IndexRepairViewModel
    {

        public IEnumerable<Repair> Repairs { get; set; }
        public Repair Repair { get; set; }
        public List<string> CustomerNames { get; set; }

        public IndexRepairViewModel()
        {
            CustomerNames = new List<string>();
        }
    }
}