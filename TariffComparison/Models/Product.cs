using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TariffComparison.Models
{
    public partial class Product
    {
        public int Productid { get; set; }
   
        [Required]
        [StringLength(100)]
        public string Tariffname { get; set; }
        public double? Annualcosts { get; set; }
    }
}
