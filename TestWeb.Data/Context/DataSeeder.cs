using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TestWeb.Models;

namespace TestWeb.Data.Context
{
    public static class DataSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 1,
                Name = "Category1",
                Description = "DescriptionCategory1",
            }, new Category
            {
                Id = 2,
                Name = "Category2",
                Description = "DescriptionCategory2",
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                Name = "Product1",
                Description = "Product1",
                Price = 1,
                CategoryId = 1
            });
        }
    }
}
