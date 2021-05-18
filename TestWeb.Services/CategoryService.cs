using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWeb.Models;
using TestWeb.Repositories.Interfaces;
using TestWeb.Services.Interfaces;

namespace TestWeb.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _categoryRepository.GetAllAsync();
            
        }

        public async Task<Category> AddAsync(Category product)
        {
            var result = await _categoryRepository.AddAsync(product);
            await _categoryRepository.SaveAsync();
            return result;
        }

        public async Task<Category> UpdateAsync(Category product)
        {
            var result = _categoryRepository.Update(product);
            await _categoryRepository.SaveAsync();
            return result;
        }

        public async Task<Category> RemoveAsync(int id)
        {
            var result = await _categoryRepository.RemoveAsync(id);
            await _categoryRepository.SaveAsync();
            return result;
        }

        public async Task<Category> GetWithProducts(int id)
        {
            var result = await _categoryRepository.GetWithProductsAsync();
            return result.FirstOrDefault();
        }
    }
}
