using Microsoft.EntityFrameworkCore;
using AutoPartX.DAL.EF.Models;

namespace AutoPartX.DAL.EF
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Part> Parts { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }    

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                
                optionsBuilder.UseSqlServer("Server=localhost,1433;Database=MyShopDB;User Id=sa;Password=YourStrongPassword123;TrustServerCertificate=True;");
            }
        }
    }
}