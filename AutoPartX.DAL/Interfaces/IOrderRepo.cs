using AutoPartX.DAL.EF.Models;
using System.Collections.Generic;

namespace AutoPartX.DAL.Interfaces
{
    public interface IOrderRepo : IRepository<Order, int>
    {
        
        List<Order> GetByStatus(string status);
    }
}