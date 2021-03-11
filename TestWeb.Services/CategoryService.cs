using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWeb.Repositories.Interfaces;
using TestWeb.Services.Interfaces;
using CategoryDal = TestWeb.Models.Category;
using CategoryDto = TestWeb.Services.Models.Category;

namespace TestWeb.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<CategoryDal> _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(IGenericRepository<CategoryDal> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<CategoryDto>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            var result = _mapper.Map<List<CategoryDal>, List<CategoryDto>>(categories);
            return result;
        }

        public async Task<CategoryDto> AddAsync(CategoryDto product)
        {
            var result = await _categoryRepository.AddAsync(_mapper.Map<CategoryDto, CategoryDal>(product));
            await _categoryRepository.SaveAsync();
            return _mapper.Map<CategoryDal, CategoryDto>(result);
        }

        public async Task<CategoryDto> UpdateAsync(CategoryDto product)
        {
            var result = _categoryRepository.Update(_mapper.Map<CategoryDto, CategoryDal>(product));
            await _categoryRepository.SaveAsync();
            return _mapper.Map<CategoryDal, CategoryDto>(result);
        }

        public async Task<CategoryDto> RemoveAsync(int id)
        {
            var result = await _categoryRepository.RemoveAsync(id);
            await _categoryRepository.SaveAsync();
            return _mapper.Map<CategoryDal, CategoryDto>(result);
        }

        public async Task<CategoryDto> GetWithProducts(int id)
        {
            var result = await _categoryRepository.GetAsync(x => x.Id == id, null, "Products");

            return _mapper.Map<CategoryDal, CategoryDto>(result.FirstOrDefault());
        }
    }
}
