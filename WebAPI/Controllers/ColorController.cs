using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        IColorService _colorService;

        public ColorController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _colorService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Color entity)
        {
            var result = _colorService.Add(entity);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Color entity)
        {
            var result = _colorService.Delete(entity);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Update(Color color)
        {
            var result = _colorService.Update(color);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("getbyıd")]
        public IActionResult GetById(int id)
        {
            var result = _colorService.GetById(id);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
    }
}
