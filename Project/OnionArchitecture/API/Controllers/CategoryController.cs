using Application.DTOs.CategoryDTOs;
using Application.Repositories;
using Application.ServiceManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryServiceManager _categoryServiceManager;

        public CategoryController(CategoryServiceManager categoryServiceManager)
        {
            _categoryServiceManager = categoryServiceManager;
        }

        [HttpGet("categories")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryServiceManager.GetCategoriesAsync();
            return Ok(categories);
        }

        [HttpPost("add-category")]
        public async Task<IActionResult> PostCategory([FromForm] CreateCategoryDTO categoryDTO)
        {
            await _categoryServiceManager.AddCategory(categoryDTO);
            return Ok();
        }

        [HttpGet("get-category")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _categoryServiceManager.GetCategory(id);
            return Ok(category);
        }

        [HttpDelete("delete-category")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var deletedCategory =await _categoryServiceManager.GetCategory(id);

            if (deletedCategory != null)
            {
                await _categoryServiceManager.DeleteCategory(deletedCategory);
                return Ok("Kategori Silindi!");
            }
            else
            {
                return BadRequest("Kategori bulunamadı!");
            }
        }

        [HttpPut("update-category")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            
            await _categoryServiceManager.UpdateCategory(updateCategoryDto);
            return Ok();
        }
    }
}
