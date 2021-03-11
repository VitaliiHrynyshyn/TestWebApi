using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWeb.Repositories.Interfaces;
using TestWeb.Services.Interfaces;
using ProductDal = TestWeb.Models.Product;
using ProductDto = TestWeb.Services.Models.Product;

namespace TestWeb.Services
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<ProductDal> _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IGenericRepository<ProductDal> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductDto>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();
            var result = _mapper.Map<List<ProductDal>, List<ProductDto>> (products);
            return result;
        }

        public async Task<ProductDto> AddAsync(ProductDto product)
        {
            var result = await _productRepository.AddAsync(_mapper.Map<ProductDto, ProductDal>(product));
            await _productRepository.SaveAsync();
            return _mapper.Map<ProductDal, ProductDto>(result);
        }

        public async Task<ProductDto> UpdateAsync(ProductDto product)
        {
            var existing = await _productRepository.GetByIdAsync(product.Id);

            var result = _productRepository.Update(_mapper.Map(product, existing));

            await _productRepository.SaveAsync();
            return _mapper.Map<ProductDal, ProductDto>(result);
        }

        public async Task<ProductDto> RemoveAsync(int id)
        {
            var result = await _productRepository.RemoveAsync(id);
            await _productRepository.SaveAsync();
            return _mapper.Map<ProductDal, ProductDto>(result);
        }

        public async Task<ProductDto> GetWithCategories(int id)
        {
            var result = await _productRepository.GetAsync(x => x.Id == id, null, "Category");

            return _mapper.Map<ProductDal, ProductDto>(result.FirstOrDefault());
        }
    }
}
