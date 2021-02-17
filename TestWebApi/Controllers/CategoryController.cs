using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestWeb.Services;
using TestWeb.Services.Models;

namespace TestWebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<List<Category>> GetAll()
        {
            return await _categoryService.GetAllAsync();
        }

        [HttpPost]
        public async Task<Category> Add(Category category)
        {
            return await _categoryService.AddAsync(category);
        }

        [HttpPut]
        public async Task<Category> Update(Category category)
        {
            return await _categoryService.UpdateAsync(category);
        }

        [HttpDelete]
        public async Task<Category> Remove(int id)
        {
            return await _categoryService.RemoveAsync(id);
        }

        [HttpGet]
        public async Task<Category> GetWithProducts(int id)
        {
            return await _categoryService.GetWithProducts(id);
        }
    }
}
