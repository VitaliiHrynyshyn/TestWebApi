using System.Collections.Generic;
using System.Threading.Tasks;
using TestWeb.Models;

namespace TestWeb.Application.Services.Base
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllAsync();
        Task<Category> AddAsync(Category product);
        Task<Category> UpdateAsync(Category product);
        Task<Category> RemoveAsync(int id);
        Task<Category> GetWithProducts(int id);
    }
}
