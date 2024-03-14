using Lessonapi.Data;
using Lessonapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lessonapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var lstCategory = _context.categories.ToList();
            return Ok(lstCategory);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var category = _context.categories.SingleOrDefault(c => c.Id == id);
            if(category != null)
            {
                return Ok(category);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Create (CategoryModel model)
        {
            try
            {
                var category = new Category
                {
                    Name = model.Name
                };
                _context.Add(category);
                _context.SaveChanges();
                return Ok(category);
            }catch 
            {
                return BadRequest();
            }
        }


        [HttpPut("{id}")]
        public IActionResult Edit(int id, CategoryModel model)
        {
            var category = _context.categories.SingleOrDefault(c => c.Id == id);
            if (category != null)
            {
                category.Name = model.Name;
                _context.SaveChanges();  // Lưu thay đổi vào cơ sở dữ liệu
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category = _context.categories.SingleOrDefault(c => c.Id == id);
            if (category != null)
            {
                _context.Remove(category);
                _context.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                return NoContent();
            }
            return NotFound();
        }
    }   
}
