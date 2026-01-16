using AutoPartX.DAL.EF.Models;

namespace AutoPartX.DAL.Interfaces
{
    public interface ICategoryRepo : IRepository<Category, int>
    {
        Category GetWithParts(int id); 
    }
}