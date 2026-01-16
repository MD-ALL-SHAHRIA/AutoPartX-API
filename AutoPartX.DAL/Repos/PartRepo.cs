using System.Collections.Generic;
using System.Linq;
using AutoPartX.DAL.EF;
using AutoPartX.DAL.EF.Models;
using AutoPartX.DAL.Interfaces;

namespace AutoPartX.DAL.Repos
{
    internal class PartRepo : IPartRepo
    {
        private readonly AppDbContext _context;

        public PartRepo(AppDbContext context)
        {
            _context = context;
        }

        
        public void Create(Part obj)
        {
            _context.Parts.Add(obj);
            _context.SaveChanges();
        }

        public bool Delete(int id)
        {
            var data = _context.Parts.Find(id);
            if (data == null) return false;
            _context.Parts.Remove(data);
            return _context.SaveChanges() > 0;
        }

        public List<Part> GetAll()
        {
            return _context.Parts.ToList();
        }

        public Part GetById(int id)
        {
            return _context.Parts.Find(id);
        }

        public bool Update(Part obj)
        {
            _context.Parts.Update(obj);
            return _context.SaveChanges() > 0;
        }

        
        public List<Part> Search(string query)
        {
            return _context.Parts.Where(p => p.Name.Contains(query) || p.OemNumber.Contains(query)).ToList();
        }

        public List<Part> GetByPriceRange(decimal min, decimal max)
        {
            return _context.Parts.Where(p => p.Price >= min && p.Price <= max).ToList();
        }

        public List<Part> GetLowStock(int doorway)
        {
            return _context.Parts.Where(p => p.StockQuantity <= doorway).ToList();
        }

        public decimal GetTotalValue()
        {
            
            if (!_context.Parts.Any()) return 0;
            return _context.Parts.Sum(p => p.Price * p.StockQuantity);
        }

        public bool UpdateStock(int id, int qty)
        {
            var part = _context.Parts.Find(id);
            if (part == null) return false;
            part.StockQuantity = qty;
            return _context.SaveChanges() > 0;
        }
    }
}