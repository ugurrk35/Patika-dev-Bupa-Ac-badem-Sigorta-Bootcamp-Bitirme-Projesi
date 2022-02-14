using Bupa.Bll.Abstract;
using Bupa.Data.Abstract;
using Bupa.Entity.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bupa.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;


        public ProductController(IProductService productService )
        {
            _productService = productService;
       

        }

        // GET: api/<ProductController>
        [HttpGet]
        public IActionResult GetAllEnd()
        {
            var products = _productService.GetAll();
            return Ok(products);

        }

  

        // POST api/<ProductController>

        [HttpPost]
        public IActionResult Add([FromBody] Product customer)
        {
            if (ModelState.IsValid)
            {
                _productService.Create(customer);


                return Ok(customer);
            }

            return Ok("Data didn't save");

        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Product id)
        {
            if (ModelState.IsValid)
            {
                _productService.Update(id);


                return Ok(id);
            }
            
            return BadRequest();
        }
    

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (ModelState.IsValid)
            {
                _productService.Delete(id);


                return Ok();
            }

           return NotFound();
        }
    }
}
   


