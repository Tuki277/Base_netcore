using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using api_base.Models;
using api_base.Dto;
using api_base.Services;
using Hellang.Middleware.ProblemDetails;

namespace api_base.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private CategoryService _categoryService;
        private IMapper _mapper;

        public CategoryController(IMapper mapper, CategoryService categoryService)
        {
            _mapper = mapper;
            _categoryService = categoryService;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        public IActionResult GetCategory()
        {
            try
            {
                var categories = _categoryService.GetCategories();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{categoryId}")]
        [ProducesResponseType(200, Type = typeof(Category))]
        [ProducesResponseType(400)]
        public IActionResult GetCategory(int categoryId)
        {

            try
            {
                var categoryResult = _categoryService.GetCategory(categoryId);
                return Ok(categoryResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("pokemon/{categoryId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        [ProducesResponseType(400)]
        public IActionResult GetPokemonByCategoryId(int categoryId)
        {
            try
            {
                var result = _categoryService.GetPokemonById(categoryId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateCategory([FromBody] CategoryNonIdDto categoryCreate)
        {
            _categoryService.CreateCategory(categoryCreate);
            return NoContent();
        }

        [HttpPut("{categoryId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCategory(int categoryId, [FromBody]CategoryNonIdDto updatedCategory)
        {
            _categoryService.UpdateCategory(categoryId, updatedCategory);
            return Ok();
        }

        [HttpDelete("{categoryId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteCategory(int categoryId)
        {
            _categoryService.DeleteCategory(categoryId);
            return Ok();
        }
    }
}