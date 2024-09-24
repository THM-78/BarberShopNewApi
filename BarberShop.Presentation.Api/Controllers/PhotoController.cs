using BarberShop.Application.Interfaces;
using BarberShop.Application.ViewModels.WorkPhoto;
using BarberShop.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private readonly IWorkPhotoService _workPhotoService;
        public PhotoController(IWorkPhotoService workPhotoService)
        {
            _workPhotoService = workPhotoService;
        }

        [HttpPost("AddWorkPhoto")]
        public IActionResult AddWorkPhoto(CreateWorkPhotoVm workPhotoVm)
        {
            bool result = _workPhotoService.Add(workPhotoVm);
            if (result)
                return Ok();
            return BadRequest();
        }

        [HttpGet("AllWorkPhotos")]
        public IActionResult WorkPhotos()
        {
            var result = _workPhotoService.All();
            return Ok(result);

        }

        [HttpGet("WorkPhotoById/{id}")]
        public IActionResult WorkPhotoById(int id)
        {
            var result = _workPhotoService.GetById(id);
            return Ok(result);
        }

        [HttpPost("EditWorkPhoto")]
        public IActionResult EditWorkPhoto(EditWorkPhotoVm workPhotoVm)
        {
            try
            {
                _workPhotoService.Update(workPhotoVm);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
