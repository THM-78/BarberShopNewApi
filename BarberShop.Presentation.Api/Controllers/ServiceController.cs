using BarberShop.Application.Interfaces;
using BarberShop.Application.ViewModels.Service;
using BarberShop.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;
        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet("ServiceByType/{type}")]
        public IActionResult ServiceByType(string type)
        {
            var result = _serviceService.GetByType(type);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }

        [HttpGet("ServiceIntervalById/{id}")]
        public ActionResult<int> ServiceIntervalById(int id)
        {
            int result = _serviceService.GetIntervalTimeById(id);
            if (result == 0)
                return BadRequest();
            return Ok(new { periodOfTime = result});
        }
        [HttpGet("ServiceById/{id}")]
        public IActionResult ServiceById(int id)
        {
            var result = _serviceService.GetById(id);
            if (result == null)
                return BadRequest();
            return Ok(result);
        }

        [HttpGet("ReservationServices")]
        public IActionResult ReservationServices()
        {
            var result = _serviceService.GetReservationServices();
            if(result == null)
                return BadRequest();
            return Ok(result);  
        }

        [HttpGet("AllServices")]
        public IActionResult AllServices()
        {
            return Ok(_serviceService.All());
        }

        [HttpPost("AddService")]
        public IActionResult AddService(CreateServiceVm service)
        {
            var result = _serviceService.Add(service);
            return Ok(result);
        }


        [HttpPost("EditService")]
        public IActionResult EditService(EditServiceVm service)
        {
            try
            {
                _serviceService.Update(service);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("DelService/{id}")]
        public IActionResult DeleteService(int id)
        {
            bool result = _serviceService.Delete(id);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
