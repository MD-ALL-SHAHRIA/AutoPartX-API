using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoPartX.DAL.EF.Models
{
    public class Part
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string OemNumber { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}