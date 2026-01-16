using System.ComponentModel.DataAnnotations;

namespace AutoPartX.BLL.DTOs
{
    public class PartDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string OemNumber { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be positive")]
        public decimal Price { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Stock cannot be negative")]
        public int StockQuantity { get; set; }

        
        [Required]
        public int CategoryId { get; set; }
    }
}