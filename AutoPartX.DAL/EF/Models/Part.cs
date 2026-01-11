using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartX.DAL.EF.Models
{
    public class Part
    {
        public int Id { get; set; }
        public string PartName { get; set; } = string.Empty;
        public string OEMNumber { get; set; } = string.Empty; 
        public int StockQuantity { get; set; } 
        public decimal Price { get; set; }
        public DateTime LastRestocked { get; set; } 
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

    }
}