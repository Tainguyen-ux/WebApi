using _01_GettingStarted.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _01_GettingStarted.Controllers
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
        public IActionResult GetId(string id)
        {
            try
            {
                var product = products.SingleOrDefault(x => x.ID == Guid.Parse(id));
                if (product == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(product);
                }
            }
            catch
            {
                return BadRequest();
            }
            
        }

        [HttpPost]
        public IActionResult Create(ProductVM productVM) 
        {
            var product=new Product()
            {
                ID=Guid.NewGuid(),
                Name=productVM.Name,
                Price=productVM.Price,
            };
            products.Add(product);
            return Ok(new
            {
                Code=200,
                Id=product.ID,
            });
        }

        [HttpPut("{id}")]
        public IActionResult Edit(string id, Product product) 
        {
            try
            {
                var producation = products.SingleOrDefault(x=>x.ID == Guid.Parse(id));
                if(producation == null)
                {
                    return NotFound(new
                    {
                        Code=404,
                        Message="Không tìm thấy dữ liệu"
                    });
                }
                else
                {
                    producation.Name= product.Name;
                    producation.Price= product.Price;

                    return Ok(producation);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
