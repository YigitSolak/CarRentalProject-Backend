using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        readonly ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("getbyıd")]
        public IActionResult GetById(int id)
        {
            var result = _carImageService.GetById(id);

            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("getlistbycarıd")]
        public IActionResult GetListByCarId(int carId)
        {
            var result = _carImageService.GetListByCarId(carId);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm] CarImage carImage)
        {
            var result = _carImageService.Add(carImage);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPut("update")]
        public IActionResult Update([FromForm] CarImage carImage)
        {
            var result = _carImageService.Update(carImage);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete([FromForm] CarImage carImage)
        {
            var result = _carImageService.Delete(carImage);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
    }
}