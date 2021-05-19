using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWeb.Application.Services.Base;
using TestWeb.Models;
using TestWeb.Persistence.Base;

namespace TestWeb.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product> AddAsync(Product product)
        {
            var result = await _productRepository.AddAsync(product);
            await _productRepository.SaveAsync();
            return result;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            //var existing = await _productRepository.GetByIdAsync(product.Id);
            //_productRepository.Update(existing);
            //await _productRepository.SaveAsync();
            //return existing;

            var result = _productRepository.Update(product);
            await _productRepository.SaveAsync();
            return result;
        }

        public async Task<Product> RemoveAsync(int id)
        {
            var result = await _productRepository.RemoveAsync(id);
            await _productRepository.SaveAsync();
            return result;
        }

        public async Task<Product> GetWithCategories(int id)
        {
            var result = await _productRepository.GetWithCategoryAsync();
            return result.FirstOrDefault();
        }
    }
}
