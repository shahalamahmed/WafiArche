using Microsoft.AspNetCore.Mvc;
using WafiArche.Application.Categories;
using WafiArche.Application.Categories.Dtos;
using System;
using System.Collections.Generic;

namespace WafiArche.Api.Categories
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryAppService _categoryAppService;

        public CategoryController(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }

        // Create a new category
        [HttpPost]
        public ActionResult<CategoryDto> CreateCategory([FromBody] CategoryDto categoryDto)
        {
            var createdCategory = _categoryAppService.CreateCategory(categoryDto);
            return CreatedAtAction(nameof(GetCategoryById), new { id = createdCategory.CategoryID }, createdCategory);
        }

        // Get all categories
        [HttpGet]
        public ActionResult<IEnumerable<CategoryDto>> GetAllCategories()
        {
            var categories = _categoryAppService.GetAllCategories();
            return Ok(categories);
        }

        // Get a single category by ID
        [HttpGet("{id}")]
        public ActionResult<CategoryDto> GetCategoryById(int id)
        {
            try
            {
                var category = _categoryAppService.GetCategoryById(id);
                return Ok(category);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // Update a category
        [HttpPut("{id}")]
        public ActionResult<CategoryDto> UpdateCategory(int id, [FromBody] CategoryDto updatedCategoryDto)
        {
            if (updatedCategoryDto == null)
                return BadRequest("Updated category data is required.");

            try
            {
                var category = _categoryAppService.UpdateCategory(id, updatedCategoryDto);
                return Ok(category);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        // Delete a category
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            try
            {
                _categoryAppService.DeleteCategory(id);
                return NoContent(); // HTTP 204
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
