using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestWeb.Services;
using TestWeb.Services.Interfaces;
using TestWeb.Services.Models;

namespace TestWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _productService.GetAllAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Product product)
        {
            var result = await _productService.AddAsync(product);
            return Ok(result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, Product product)
        {
            product.Id = id;

            var result = await _productService.UpdateAsync(product);

            return result == null ? NotFound() : Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Remove(int id)
        {
            var result = await _productService.RemoveAsync(id);

            return result == null ? NotFound() : Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetWithProducts(int id)
        {
            var result = await _productService.GetWithCategories(id);

            return result == null ? NotFound() : Ok(result);
        }
    }
}
