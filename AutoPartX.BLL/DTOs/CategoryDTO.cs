using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; 

namespace AutoPartX.BLL.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

       
        public List<PartDTO>? Parts { get; set; } 
    }
}