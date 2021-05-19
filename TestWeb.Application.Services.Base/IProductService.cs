using System.Collections.Generic;
using System.Threading.Tasks;
using TestWeb.Models;

namespace TestWeb.Application.Services.Base
{
    public interface IProductService
    {
        Task<List<Product>> GetAllAsync();
        Task<Product> AddAsync(Product product);
        Task<Product> UpdateAsync(Product product);
        Task<Product> RemoveAsync(int id);

        Task<Product> GetWithCategories(int id);
    }
}
