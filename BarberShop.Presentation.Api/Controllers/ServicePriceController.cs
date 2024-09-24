using BarberShop.Application.Interfaces;
using BarberShop.Application.ViewModels.ServicePriceRel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarberShop.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicePriceController : ControllerBase
    {
        private readonly IServicePriceRelService _servicePriceRelService;
        public ServicePriceController(IServicePriceRelService servicePriceRelService)
        {
            _servicePriceRelService = servicePriceRelService;
        }

        [HttpPost("Add")]
        public IActionResult AddServicePrice(CreateServicePriceVm servicePriceRel)
        {
            bool addResult = _servicePriceRelService.AddReservation(servicePriceRel);
            if(addResult)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost("GetPrice")]
        public IActionResult GetPrice(PriceVm priceVm)
        {
            try
            {
                string price = _servicePriceRelService.GetPrice(priceVm);
                return Ok(new { Price = price });

            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("All")]
        public IActionResult All()
        {
            return Ok(_servicePriceRelService.All());
        }

        [HttpGet("GetByService/{serviceId}")]
        public IActionResult GetStylistByServiceId(int serviceId)
        {
            return Ok(_servicePriceRelService.GetStylistByServiceId(serviceId));
        }

        [HttpGet("Get/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_servicePriceRelService.Get(id));
        }

        [HttpPost("Edit")]
        public IActionResult EditServicePrice(EditServicePriceVm servicePriceVm)
        {
            try
            {
                _servicePriceRelService.Update(servicePriceVm);
                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            bool delResult = _servicePriceRelService.RemoveReservation(id);
            if (delResult)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
