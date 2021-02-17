using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestWeb.Services;
using TestWeb.Services.Models;

namespace TestWebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<List<Product>> GetAll()
        {
            return await _productService.GetAllAsync();
        }

        [HttpPost]
        public async Task<Product> Add(Product product)
        {
            return await _productService.AddAsync(product);
        }

        [HttpPut]
        public async Task<Product> Update(Product product)
        {
            return await _productService.UpdateAsync(product);
        }


        [HttpDelete]
        public async Task<Product> Remove(int id)
        {
            return await _productService.RemoveAsync(id);
        }

        [HttpGet]
        public async Task<Product> GetWithCategories(int id)
        {
            return await _productService.GetWithCategories(id);
        }
    }
}
