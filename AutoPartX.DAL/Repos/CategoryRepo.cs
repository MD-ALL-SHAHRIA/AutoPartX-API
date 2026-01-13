using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AutoPartX.DAL.EF;
using AutoPartX.DAL.EF.Models;

namespace AutoPartX.DAL.Repos
{
    public class CategoryRepo
    {
        public AppDbContext _context;

        public CategoryRepo(AppDbContext context)
        {
            _context = context;
        }
        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
        }
        public Category GetById(int id)
        {
            return _context.Categories.Find(id);
        }

        public void Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

    }
}