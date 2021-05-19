using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestWeb.Application.Services.Base;
using TestWeb.Models;
using TestWebApi.Model;


namespace TestWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _productService.GetAllAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductViewModel product)
        {
            var result = await _productService.AddAsync(_mapper.Map<ProductViewModel, Product>(product));
            return Ok(result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, ProductViewModel product)
        {
            product.Id = id;

            var result = await _productService.UpdateAsync(_mapper.Map<ProductViewModel, Product>(product));

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
