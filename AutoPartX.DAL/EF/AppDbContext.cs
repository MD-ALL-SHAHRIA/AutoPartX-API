using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoPartX.DAL.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoPartX.DAL.EF
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        
        public DbSet<Category> Categories { get; set; }
        public DbSet<Part> Parts { get; set; }

    }
}