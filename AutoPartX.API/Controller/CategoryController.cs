using Microsoft.AspNetCore.Mvc;
using AutoPartX.BLL.Services;
using AutoPartX.BLL.DTOs;

namespace AutoPartX.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _service;

        public CategoryController(CategoryService service)
        {
            _service = service;
        }

        [HttpGet("all")]
        public IActionResult Get()
        {
            return Ok(_service.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = _service.Get(id);
            if (data == null) return NotFound("Category not found");
            return Ok(data);
        }

        [HttpPost("create")]
        public IActionResult Post(CategoryDTO dto)
        {
            _service.Add(dto);
            return Ok("Category created successfully");
        }
    }
}