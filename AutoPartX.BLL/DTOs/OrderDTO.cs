using System;
using System.Collections.Generic;

namespace AutoPartX.BLL.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }

       
        public DateTime? OrderDate { get; set; } 
        
        public string? Status { get; set; } 
        
        public decimal TotalAmount { get; set; }
        
        public List<OrderDetailDTO> OrderDetails { get; set; }
    }
}