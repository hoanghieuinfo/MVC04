using Microsoft.EntityFrameworkCore;
using MVC04.Models;

namespace MVC04.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("tblProducts");
            modelBuilder.Entity<Product>()
                .HasIndex(p => p.ProductName)
                .IsUnique();
        }
    }
}