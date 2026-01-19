using Microsoft.AspNetCore.Mvc;
using AutoPartX.BLL.Services;
using AutoPartX.BLL.DTOs;

namespace AutoPartX.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _service;

        public OrderController(OrderService service)
        {
            _service = service;
        }

        [HttpGet("all")]
        public IActionResult GetAll() => Ok(_service.Get());

        [HttpGet("{id}")]
        public IActionResult Get(int id) => Ok(_service.Get(id));

        [HttpPost("place")]
        public IActionResult PlaceOrder(OrderDTO dto)
        {
           
            var result = _service.PlaceOrder(dto);
            if (result)
            {
                return Ok("Order Placed Successfully");
            }
            return BadRequest("Order Failed! Check Stock or Part ID.");
        }
    }
}