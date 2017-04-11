using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CriticalWebApp.Models;

namespace CriticalWebApp.ViewModels
{
    public class LogShipmentViewModel
    {
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public List<int> SerialNumberIds { get; set; }
        public DateTime Shipdate { get; set; }

    }
   
}