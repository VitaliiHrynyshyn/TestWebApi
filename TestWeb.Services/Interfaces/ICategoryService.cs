using System.Collections.Generic;
using System.Threading.Tasks;
using CategoryDto = TestWeb.Services.Models.Category;

namespace TestWeb.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllAsync();
        Task<CategoryDto> AddAsync(CategoryDto product);
        Task<CategoryDto> UpdateAsync(CategoryDto product);
        Task<CategoryDto> RemoveAsync(int id);
        Task<CategoryDto> GetWithProducts(int id);
    }
}
