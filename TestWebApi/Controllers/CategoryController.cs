using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestWeb.Services;
using TestWeb.Services.Interfaces;
using TestWeb.Services.Models;

namespace TestWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _categoryService.GetAllAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Category category)
        {
            var result = await _categoryService.AddAsync(category);
            return Ok(result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, Category category)
        {
            category.Id = id;

            var result = await _categoryService.UpdateAsync(category);

            return result == null ? NotFound() : Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Remove(int id)
        {
            var result = await _categoryService.RemoveAsync(id);

            return result == null ? NotFound() : Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetWithProducts(int id)
        {
            var result = await _categoryService.GetWithProducts(id);

            return result == null ? NotFound() : Ok(result);
        }
    }
}
