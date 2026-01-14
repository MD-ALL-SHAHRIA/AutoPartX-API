using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartX.BLL.DTOs
{
    public class PartDTO
    {
        public int Id { get; set; } 
        public string PartName { get; set; } = string.Empty;
        public string OEMNumber { get; set; } = string.Empty; 
        public int StockQuantity { get; set; } 
        public decimal Price { get; set; } 
        public DateTime LastRestocked { get; set; } 
        public int CategoryId { get; set; } 

        // flat relation
        public string? CategoryName { get; set; } 

    }
}