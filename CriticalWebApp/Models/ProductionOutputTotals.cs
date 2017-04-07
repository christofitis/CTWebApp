﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CriticalWebApp.Models
{
    public class ProductionOutputTotals
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public string Employee { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; }

    }
}