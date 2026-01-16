using System.Collections.Generic;
using AutoPartX.DAL.EF.Models;

namespace AutoPartX.DAL.Interfaces
{
   
    public interface IPartRepo : IRepository<Part, int>
    {
        List<Part> Search(string query);
        List<Part> GetByPriceRange(decimal min, decimal max);
        List<Part> GetLowStock(int doorway);
        decimal GetTotalValue(); 
        bool UpdateStock(int id, int qty); 
    }
}