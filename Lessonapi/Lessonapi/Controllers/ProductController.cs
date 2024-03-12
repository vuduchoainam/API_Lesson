using Lessonapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lessonapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public static List<Product> products = new List<Product>();

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            try
            {
                var product = products.FirstOrDefault(p => p.Id == Guid.Parse(id));
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        [HttpPost]
        public IActionResult Create(ProductVM productVM)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = productVM.Name,
                Price = productVM.Price,
            };
            products.Add(product);
            return Ok(new
            {
                Success = true, Data = product
            });
        }

        [HttpPut("{id}")]
        public IActionResult Edit(string id, Product productEdit)
        {
            try
            {
                var product = products.FirstOrDefault(p => p.Id == Guid.Parse(id));
                if (product == null)
                {
                    return NotFound();
                }
                if (id != product.Id.ToString() )
                {
                    return BadRequest();
                }    
                //update
                product.Name = productEdit.Name;
                product.Price = productEdit.Price;

                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var product = products.FirstOrDefault(p => p.Id == Guid.Parse(id));
                if (product == null)
                {
                    return NotFound();
                }
                if (id != product.Id.ToString())
                {
                    return BadRequest();
                }
                //delete
                products.Remove(product);

                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
