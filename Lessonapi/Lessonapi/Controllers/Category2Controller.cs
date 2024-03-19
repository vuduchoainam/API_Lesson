using Lessonapi.Data;
using Lessonapi.Models;
using Lessonapi.Repository;
using Lessonapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lessonapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Category2Controller : Controller
    {
        private readonly ICategoryService _categoryService;

        public Category2Controller(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var lstCategory = _categoryService.GetAll();
                return Ok(lstCategory);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var data = _categoryService.GetById(id);
                if(data != null)
                {
                    return Ok(data);
                }   return NotFound();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, CategoryModel model)
        {
            try
            {
                _categoryService.Edit(id, model);
                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception for debugging purposes
                // logger.LogError(ex, "An error occurred while editing the category.");

                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request. Please try again later.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _categoryService.Delete(id);
                return Ok();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult Create(CategoryModel model)
        {
            try
            {
                _categoryService.Add(model);
                return Ok(model);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
