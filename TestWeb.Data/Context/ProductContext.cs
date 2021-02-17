using Microsoft.EntityFrameworkCore;
using TestWeb.Data.Models;

namespace TestWeb.Data.Context
{
    public class ProductContext : DbContext
    {
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }

        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
        }
    }
}
