using Bupa.Bll.Abstract;
using Bupa.Data.Abstract;
using Bupa.Entity.Dtos;
using Bupa.Entity.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bupa.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService=customerService;
      
        }

        [HttpGet]
        public  IActionResult GetAll()
        {
            try { 
            var customers = _customerService.GetAll();
            return Ok(customers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }

        }
        [HttpPost]
        public IActionResult Add([FromBody]Customer customer)
        {
         var aa = _customerService.Create(customer);
            return Ok(aa);

          
        }

        [HttpGet("{id}")]
        public IActionResult CustomerById(int id)
        {
            var customer = _customerService.GetCustomerById(id);
            if (customer != null)
            {
                return Ok(customer);
            }
           else 
            {
                return NotFound("Müşteri Bulunamadı");

            }
        }


        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (ModelState.IsValid)
            {
                _customerService.Delete(id);


                return Ok();
            }

            return NotFound();
        }
    }
}
