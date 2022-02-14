using Bupa.Bll.Abstract;
using Bupa.Entity.Dtos;
using Bupa.Entity.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bupa.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/<OrderController>
        [HttpGet]
        public IActionResult GetAll()
        {
            var orders = _orderService.GetAll();
            return Ok(orders);

        }

        [HttpGet("all")]
        public IActionResult GetOrderWithCustomerAll()
        {
            var orders = _orderService.GetWithCustomer();
            return Ok(orders);

        }
        [HttpGet("{id}")]
        public IActionResult GetOrderById(int id)
        {
            var orders = _orderService.GetOrderById(id);
            return Ok(orders);

        }

    

        // POST api/<OrderController>
        [HttpPost]
        public IActionResult Add([FromBody] CustomerOrderOrderDetails order)
        {
            if (ModelState.IsValid)
            {
                _orderService.CreateOrder(order);


                return Ok(order);
            }

            return Ok("Data didn't save");

        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (ModelState.IsValid)
            {
                _orderService.Delete(id);


                return Ok();
            }

            return NotFound();
        }
    }
}
