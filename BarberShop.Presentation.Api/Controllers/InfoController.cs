using BarberShop.Application.Interfaces;
using BarberShop.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarberShop.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private readonly IinfoService _IinfoService;
        public InfoController(IinfoService iinfoService)
        {
            _IinfoService = iinfoService;
        }

        [HttpGet("Get")]
        public IActionResult GetInfo()
        {
            return Ok(_IinfoService.GetByInfo());
        }

        [HttpGet("Get/{id}")]
        public IActionResult GetInfoById(int id)
        {
            return Ok(_IinfoService.GetById(id));
        }

        [HttpPost("Edit")]
        public IActionResult EditInfo(TblBarbershopInfo barbershopInfo)
        {
            try
            {
                _IinfoService.Update(barbershopInfo);
                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
