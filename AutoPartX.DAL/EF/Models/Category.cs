using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutoPartX.DAL.EF.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        
        public virtual ICollection<Part> Parts { get; set; }

        public Category()
        {
            Parts = new List<Part>();
        }
    }
}