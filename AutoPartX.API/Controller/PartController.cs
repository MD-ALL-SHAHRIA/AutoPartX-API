using Microsoft.AspNetCore.Mvc;
using AutoPartX.BLL.Services;
using AutoPartX.BLL.DTOs;

namespace AutoPartX.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartController : ControllerBase
    {
        private readonly PartService _service;

        public PartController(PartService service)
        {
            _service = service;
        }

        [HttpGet("all")]
        public IActionResult GetAll() => Ok(_service.Get());

        [HttpGet("{id}")]
        public IActionResult GetById(int id) => Ok(_service.Get(id));

        [HttpPost("add")]
        public IActionResult Create(PartDTO dto)
        {
            _service.Add(dto);
            return Ok("Part added successfully");
        }
        
        [HttpPut("update")]
        public IActionResult Update(PartDTO dto)
        {
            _service.Update(dto);
            return Ok("Updated");
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id) => Ok(_service.Delete(id));

        
        [HttpGet("search")]
        public IActionResult Search(string q) => Ok(_service.Search(q));

        [HttpGet("price-range")]
        public IActionResult PriceRange(decimal min, decimal max) => Ok(_service.GetByPriceRange(min, max));

        [HttpGet("low-stock")]
        public IActionResult LowStock(int doorway) => Ok(_service.GetLowStock(doorway));

        [HttpGet("total-value")]
        public IActionResult TotalValue() => Ok(_service.GetTotalValue());

        [HttpPost("update-stock")]
        public IActionResult UpdateStock(int id, int qty)
        {
             if(_service.UpdateStock(id, qty)) return Ok("Stock updated");
             return BadRequest("Failed");
        }
    }
}