using Lessonapi.Data;
using Lessonapi.Models;
using Lessonapi.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lessonapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Category2Controller : Controller
    {
        private ICategoryRepository _categoryRepository;

        public Category2Controller(ICategoryRepository categoryRepository) 
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var lstCategory = _categoryRepository.GetAll();
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
                var data = _categoryRepository.GetById(id);
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
                _categoryRepository.Edit(id, model);
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
                _categoryRepository.Delete(id);
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
                _categoryRepository.Add(model);
                return Ok(model);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
