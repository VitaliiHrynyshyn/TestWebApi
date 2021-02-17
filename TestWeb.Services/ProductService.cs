using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestWeb.Data.Models;
using TestWeb.Repositories;
using TestWeb.Services.Models;

namespace TestWeb.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllAsync();
        Task<Product> AddAsync(Product product);
        Task<Product> UpdateAsync(Product product);
        Task<Product> RemoveAsync(int id);

        Task<Product> GetWithCategories(int id);
    }

    public class ProductService : IProductService
    {
        private readonly IGenericRepository<ProductEntity> _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IGenericRepository<ProductEntity> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            var products = await _productRepository.GetAllAsync();
            var result = _mapper.Map<List<ProductEntity>, List<Product>> (products);
            return result;
        }

        public async Task<Product> AddAsync(Product product)
        {
            var result = await _productRepository.AddAsync(_mapper.Map<Product, ProductEntity>(product));
            await _productRepository.SaveAsync();
            return _mapper.Map<ProductEntity, Product>(result);
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            var result = _productRepository.Update(_mapper.Map<Product, ProductEntity>(product));
            await _productRepository.SaveAsync();
            return _mapper.Map<ProductEntity, Product>(result);
        }

        public async Task<Product> RemoveAsync(int id)
        {
            var result = await _productRepository.RemoveAsync(id);
            await _productRepository.SaveAsync();
            return _mapper.Map<ProductEntity, Product>(result);
        }

        public async Task<Product> GetWithCategories(int id)
        {
            var result = await _productRepository.GetAsync(products =>
                products
                    .Include(x => x.Category)
                    .Where(x => x.Id == id));

            return _mapper.Map<ProductEntity, Product>(result.FirstOrDefault());
        }
    }
}
