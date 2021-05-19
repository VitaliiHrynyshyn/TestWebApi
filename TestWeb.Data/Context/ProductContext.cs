using Microsoft.EntityFrameworkCore;
using TestWeb.Models;

namespace TestWeb.Persistence.Context
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DataSeeder.Seed(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasOne(s => s.Category)
                .WithMany(g => g.Products)
                .HasForeignKey(s => s.CategoryId);
        }
    }
}
