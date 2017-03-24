using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CriticalWebApp.Models;
using System.ComponentModel.DataAnnotations;

namespace CriticalWebApp.ViewModels
{
    public class CreateSerialNumberViewModel
    {
        [Required]
        public SerialNumber SerialNumber { get; set; }
        public List<Product> Products { get; set; }
        public Product Product { get; set; }
        [Required]
        public int EndSerialNumber { get; set; }
        public bool IsSingleEntry { get; set; }

        public List<string> ProductNames { get; set; }


        public CreateSerialNumberViewModel()
        {
            ProductNames = new List<string>();
            IsSingleEntry = false;
            EndSerialNumber = 0;
        }
    }
}