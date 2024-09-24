using BarberShop.Application.Interfaces;
using BarberShop.Application.ViewModels.DiscountCode;
using BarberShop.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace BarberShop.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountCodeController : ControllerBase
    {
        private readonly IDiscountCodeService _discountCodeService;
        public DiscountCodeController(IDiscountCodeService discountCodeService)
        {
            _discountCodeService = discountCodeService;
        }

        [HttpGet("AllDiscountCode")]
        public IActionResult AllDiscountCode()
        {
            return Ok(_discountCodeService.All());
        }

        [HttpPost("AddDiscode")]
        public IActionResult AddDiscode(CreateDisCodeVm discountCode)
        {
            bool result = _discountCodeService.Add(discountCode);
            if (result) 
                return Ok();
            return BadRequest();
        }
        [HttpGet("DiscodeById/{id}")]
        public IActionResult DiscodeById(int id)
        {
            var result = _discountCodeService.GetById(id);
            return Ok(result);
        }

        [HttpPost("ValidateDiscode")]
        public IActionResult validate(ValidateDisCodeVm DisCode)
        {
            return Ok(_discountCodeService.ValidateDisCode(DisCode));
        }
        [HttpDelete("DelDiscode/{id}")]
        public IActionResult DelDiscode(int id)
        {
            bool result = _discountCodeService.Delete(id);
            if(result)
                return Ok();
            return BadRequest();
        }

        
    }
}
