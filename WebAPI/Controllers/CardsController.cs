using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private ICardService _cardService;

        public CardsController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _cardService.GetAll();
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("getbycustomerıd")]
        public IActionResult GetByCustomerId(int customerId)
        {
            var result = _cardService.GetByCustomerId(customerId);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Card card)
        {
            var result = _cardService.Add(card);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPut("update")]
        public IActionResult Update(Card card)
        {
            var result = _cardService.Update(card);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Card card)
        {
            var result = _cardService.Delete(card);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
    }
}
