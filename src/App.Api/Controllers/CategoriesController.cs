using App.Api.Contracts;
using App.Core.Abstractions;
using App.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class CategoriesController : Controller
    {
        private readonly ICategoriesService _categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoriesResponse>>> GetCategories()
        {
            var categories = await _categoriesService.GetAllCategories();

            return Ok(categories
                .Select(c => new CategoriesResponse(
                    c.Id,
                    c.Title,
                    c.Description)));
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CategoriesResponse>> GetCategoryById(Guid id)
        {
            var category = await _categoriesService.GetCategoryById(id);

            if (category == null)
            {
                return NotFound($"Category with ID {id} not found.");
            }

            return new CategoriesResponse(
                category.Id,
                category.Title,
                category.Description);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateCategory([FromBody] CategoriesRequest request)
        {
            var (category, error) = Category.Create(
                Guid.NewGuid(),
                request.Title,
                request.Description);

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var categoryId = await _categoriesService.CreateCategory(category);

            return Ok(categoryId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateCategory(Guid id, [FromBody] CategoriesRequest request)
        {
            var categoryId = await _categoriesService.UpdateCategory(
                id,
                request.Title,
                request.Description);

            return Ok(categoryId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteCategory(Guid id)
        {
            var categoryId = await _categoriesService.DeleteCategory(id);

            return Ok(categoryId);
        }
    }
}
