using System.Collections.Generic;
using System.Threading.Tasks;
using TestWeb.Models;

namespace TestWeb.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllAsync();

        Task<List<Category>> GetWithProductsAsync();
        Task<Category> GetByIdAsync(object id);
        Task<Category> AddAsync(Category obj);
        Category Update(Category obj);
        Task<Category> RemoveAsync(int id);
        Task SaveAsync();
    }

}
