using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using AutoPartX.DAL.EF;
using AutoPartX.DAL.EF.Models;

namespace AutoPartX.DAL.Repos
{
    public class PartRepo
    {
        private readonly AppDbContext _context;
        public PartRepo(AppDbContext context)
        {
            _context = context;
        }

        public List<Part> GetAll()
        {
            return _context.Parts.ToList();
        }
        public Part GetById(int id)
        {
            return _context.Parts.Find(id);
        }

        public void Create(Part part)
        {
            _context.Parts.Add(part);
            _context.SaveChanges();
        }

        public void Update(Part part)
        {
            var existingPart = _context.Parts.Find(part.Id);
            if (existingPart != null)
            {
                existingPart.PartName = part.PartName;
                existingPart.OEMNumber = part.OEMNumber;
                existingPart.StockQuantity = part.StockQuantity;
                existingPart.Price = part.Price;
                existingPart.LastRestocked = DateTime.Now;
                existingPart.CategoryId = part.CategoryId;

                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var part = _context.Parts.Find(id);
            if (part != null)
            {
                _context.Parts.Remove(part);
                _context.SaveChanges();
            }
        }

        public List<Part> SearchParts(string query)
        {
            return _context.Parts
                .Where(p => p.PartName.Contains(query) || p.OEMNumber.Contains(query))
                .ToList();
        }

        public List<Part> GetPartsByPriceRange(decimal minPrice, decimal maxPrice)
        {
            return _context.Parts
                .Where(p => p.Price >= minPrice && p.Price <= maxPrice)
                .ToList();
        }

        public List<Part> GetLowStockAlert(int doorway)
        {
            return _context.Parts
                .Where(p => p.StockQuantity <= doorway)
                .ToList();
        }

        public decimal GetTotalInventoryValue()
        {
            return _context.Parts
                .Sum(p => p.Price * p.StockQuantity);
        }
        
        public bool UpdateStockLevel(int partId, int addedQuantity)
        {
            var part = _context.Parts.Find(partId);
            if (part == null)
            {
                return false;
            }

            part.StockQuantity += addedQuantity;
            part.LastRestocked = DateTime.Now;
            _context.SaveChanges();
            return true;
        }

    }
}