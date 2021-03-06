﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CriticalWebApp.Models
{
    public class ProductionOutputTotals
    {
        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }
        [Required]
        public string Product { get; set; }
        [Required]
        public string Employee { get; set; }
        [Required]
        public int Quantity { get; set; }
        public string Notes { get; set; }

    }
}