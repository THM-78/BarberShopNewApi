using BarberShop.Application.Interfaces;
using BarberShop.Application.ViewModels.HairStylist;
using BarberShop.Application.ViewModels.HairStylistLevel;
using BarberShop.Domain.Interfaces;
using BarberShop.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StylistController : ControllerBase
    {
        private readonly IStylistService _stylistService;
        private readonly IStylistLevelService _stylistLevelService;
        public StylistController(IStylistService stylistService, IStylistLevelService stylistLevelService)
        {
            _stylistService = stylistService;
            _stylistLevelService = stylistLevelService;
        }

        [HttpPost("AddHairStylist")]
        public IActionResult AddHairStylist(CreateHairStylistVm hairStylistVm)
        {
            var result = _stylistService.Add(hairStylistVm);
            if(result)
                return Ok();
            return BadRequest();
        }

        [HttpGet("AllStylists")]
        public IActionResult AllStylists()
        {
            return Ok(_stylistService.All());
        }

        [HttpGet("StylistById/{id}")]
        public IActionResult Get(int id)
        {
            var result = _stylistService.Get(id);
            if(result == null)
                return BadRequest();
            return Ok(result);
        }

        [HttpPost("EditStylist")]
        public IActionResult Edit(EditHairStylistVm stylist)
        {
            try
            {
                _stylistService.Update(stylist);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DelStylist/{id}")]
        public IActionResult delete(int id)
        {
            bool result = _stylistService.Delete(id);
            if(result)
                return Ok();
            return BadRequest();
        }

        [HttpGet("AllStylistLevels")]
        public IActionResult AllStylistLevels()
        {
            var result = _stylistLevelService.All();
            return Ok(result);
        }
        [HttpGet("GetAdminStylist/{serviceId}")]
        public IActionResult GetAdminStylist(int serviceId)
        {
            var result = _stylistService.GetAdminStylistByServiceId(serviceId);
            return Ok(result);
        }

        [HttpPost("AddStylistLevel")]
        public IActionResult AddStylistLevel(CreateStylistLevelVm stylistLevelVm)
        {
            bool result = _stylistLevelService.Add(stylistLevelVm);
            if(result)
                return Ok();
            return BadRequest();
        }

        [HttpDelete("DelStylistLevel/{id}")]
        public IActionResult DeleteStylistLevel(int id)
        {
            bool result = _stylistLevelService.Delete(id);
            if(result)
                return Ok();
            return BadRequest();
        }

        [HttpPost("EditStylistLevel")]
        public IActionResult EditLevel(EditStylistLevelVm editStylistLevelVm)
        {
            try
            {
                _stylistLevelService.Update(editStylistLevelVm);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
