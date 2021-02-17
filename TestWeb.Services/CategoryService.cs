using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestWeb.Data.Models;
using TestWeb.Repositories;
using TestWeb.Services.Models;

namespace TestWeb.Services
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllAsync();
        Task<Category> AddAsync(Category product);
        Task<Category> UpdateAsync(Category product);
        Task<Category> RemoveAsync(int id);
        Task<Category> GetWithProducts(int id);
    }

    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<CategoryEntity> _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(IGenericRepository<CategoryEntity> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            var result = _mapper.Map<List<CategoryEntity>, List<Category>>(categories);
            return result;
        }

        public async Task<Category> AddAsync(Category product)
        {
            var result = await _categoryRepository.AddAsync(_mapper.Map<Category, CategoryEntity>(product));
            await _categoryRepository.SaveAsync();
            return _mapper.Map<CategoryEntity, Category>(result);
        }

        public async Task<Category> UpdateAsync(Category product)
        {
            var result = _categoryRepository.Update(_mapper.Map<Category, CategoryEntity>(product));
            await _categoryRepository.SaveAsync();
            return _mapper.Map<CategoryEntity, Category>(result);
        }

        public async Task<Category> RemoveAsync(int id)
        {
            var result = await _categoryRepository.RemoveAsync(id);
            await _categoryRepository.SaveAsync();
            return _mapper.Map<CategoryEntity, Category>(result);
        }

        public async Task<Category> GetWithProducts(int id)
        {
            var result = await _categoryRepository.GetAsync(categories =>
                categories
                    .Include(x => x.Products)
                    .Where(x => x.Id == id));

            return _mapper.Map<CategoryEntity, Category>(result.FirstOrDefault());
        }
    }
}
