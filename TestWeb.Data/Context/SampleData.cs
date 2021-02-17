using System.Collections.Generic;
using System.Linq;
using TestWeb.Data.Models;

namespace TestWeb.Data.Context
{
    public static class SampleData
    {
        public static void Initialize(ProductContext context)
        {
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new List<CategoryEntity>
                    {
                        new CategoryEntity
                        {
                            Name = "Category1",
                            Description = "DescriptionCategory1",
                            Products = new List<ProductEntity> 
                                {
                                    new ProductEntity
                                    {
                                        Name = "Product1",
                                        Description = "Product1",
                                        Price = 1
                                    }
                                }
                        }
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
