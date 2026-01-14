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
        public IActionResult GetById(int id)
        {
            var part = _service.Get(id); 
            if (part == null) return NotFound("Part not found");
            return Ok(part);
        }

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
            return Ok("Part updated successfully");
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok("Part deleted");
        }

        [HttpGet("search")]
        public IActionResult Search(string q) => Ok(_service.Search(q));

        [HttpGet("price-range")]
        public IActionResult GetByPrice(decimal min, decimal max) 
            => Ok(_service.GetByPriceRange(min, max));

        [HttpGet("low-stock")]
        public IActionResult GetLowStock(int doorway) 
            => Ok(_service.GetLowStock(doorway));

        [HttpGet("inventory-value")]
        public IActionResult GetTotalValue() => Ok(_service.GetTotalValue());

        [HttpPatch("update-stock/{id}")]
        public IActionResult UpdateStock(int id, int qty)
        {
            var result = _service.UpdateStock(id, qty);
            if (!result) return BadRequest("Failed to update stock");
            return Ok("Stock updated");
        }
    }
}