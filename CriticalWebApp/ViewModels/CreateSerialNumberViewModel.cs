﻿using System;
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
        public IEnumerable<Product> Products { get; set; }
        public Product Product { get; set; }
        [Required]
        public int EndSerialNumber { get; set; }
        public bool IsSingleEntry { get; set; }
        public List<string> ProductNames { get; set; }
        public List<string> HardwareRevisions { get; set; }
        public List<string> SoftwareRevisions { get; set; }
        public int ProductsCount { get; set; }

        public CreateSerialNumberViewModel()
        {
            HardwareRevisions = new List<string>();
            SoftwareRevisions = new List<string>();

            //Product = new Product();
            //ProductNames = new List<string>();
            IsSingleEntry = false;
            EndSerialNumber = 0;

        }
    }
}