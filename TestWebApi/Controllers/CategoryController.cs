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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _categoryService.GetAllAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CategoryViewModel category)
        {
            var result = await _categoryService.AddAsync(_mapper.Map<CategoryViewModel, Category>(category));
            return Ok(result);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, CategoryViewModel category)
        {
            category.Id = id;

            var result = await _categoryService.UpdateAsync(_mapper.Map<CategoryViewModel, Category>(category));

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
