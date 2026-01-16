using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoPartX.DAL.EF;
using AutoPartX.DAL.EF.Models;
using AutoPartX.DAL.Interfaces;

namespace AutoPartX.DAL.Repos
{
    internal class CategoryRepo : ICategoryRepo
    {
        private readonly AppDbContext _context;

        public CategoryRepo(AppDbContext context)
        {
            _context = context;
        }

        public void Create(Category obj)
        {
            _context.Categories.Add(obj);
            _context.SaveChanges();
        }

        public bool Delete(int id)
        {
            var data = _context.Categories.Find(id);
            if (data == null) return false;
            _context.Categories.Remove(data);
            return _context.SaveChanges() > 0;
        }

        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public Category GetById(int id)
        {
            return _context.Categories.Find(id);
        }

        public bool Update(Category obj)
        {
            _context.Categories.Update(obj);
            return _context.SaveChanges() > 0;
        }

        public Category GetWithParts(int id)
        {
            return _context.Categories.Include(c => c.Parts).FirstOrDefault(c => c.Id == id);
        }
    }
}