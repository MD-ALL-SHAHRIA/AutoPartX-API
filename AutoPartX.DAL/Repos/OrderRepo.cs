using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore; 
using AutoPartX.DAL.EF;
using AutoPartX.DAL.EF.Models;
using AutoPartX.DAL.Interfaces;

namespace AutoPartX.DAL.Repos
{
    internal class OrderRepo : IOrderRepo
    {
        private readonly AppDbContext _context;

        public OrderRepo(AppDbContext context)
        {
            _context = context;
        }

        public void Create(Order obj)
        {
            _context.Orders.Add(obj);
            _context.SaveChanges();
        }

        public bool Delete(int id)
        {
            var order = _context.Orders.Find(id);
            if (order == null) return false;
            _context.Orders.Remove(order);
            return _context.SaveChanges() > 0;
        }

        public List<Order> GetAll()
        {
            
            return _context.Orders.Include(o => o.OrderDetails).ToList();
        }

        public Order GetById(int id)
        {
            return _context.Orders
                .Include(o => o.OrderDetails)
                .FirstOrDefault(o => o.Id == id);
        }

        public bool Update(Order obj)
        {
            _context.Orders.Update(obj);
            return _context.SaveChanges() > 0;
        }

        public List<Order> GetByStatus(string status)
        {
            return _context.Orders
                .Include(o => o.OrderDetails)
                .Where(o => o.Status == status).ToList();
        }
    }
}