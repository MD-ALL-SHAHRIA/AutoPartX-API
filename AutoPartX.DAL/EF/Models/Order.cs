using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutoPartX.DAL.EF.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        [Required]
        public string Status { get; set; } 

        public decimal TotalAmount { get; set; }

       
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public Order()
        {
            OrderDetails = new List<OrderDetail>();
            OrderDate = DateTime.Now;
            Status = "Pending";
        }
    }
}