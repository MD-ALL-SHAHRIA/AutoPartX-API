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
        public IActionResult GetAll() => Ok(_service.Get());

        [HttpGet("{id}")]
        public IActionResult Get(int id) => Ok(_service.Get(id));

        [HttpGet("{id}/parts")]
        public IActionResult GetWithParts(int id) => Ok(_service.GetWithParts(id)); 

        [HttpPost("create")]
        public IActionResult Create(CategoryDTO dto)
        {
            _service.Add(dto);
            return Ok("Category Created");
        }
    }
}