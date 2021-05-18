using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestWeb.Models;

namespace TestWeb.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();

        Task<List<Product>> GetWithCategoryAsync();
        Task<Product> GetByIdAsync(int id);
        Task<Product> AddAsync(Product obj);
        Product Update(Product obj);
        Task<Product> RemoveAsync(int id);
        Task SaveAsync();
    }
}
