using BarberShop.Application.Interfaces;
using BarberShop.Application.ViewModels.BeforeAfterImg;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarberShop.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeforeAfterController : ControllerBase
    {
        private readonly IBeforeAfterService _beforeAfterService;
        public BeforeAfterController(IBeforeAfterService beforeAfterService)
        {
            _beforeAfterService = beforeAfterService;
        }

        [HttpPost("Add")]
        public IActionResult AddBeforeAfterImg(CreateBeforeAfterVm beforeAfter)
        {
            bool addResult = _beforeAfterService.Add(beforeAfter);
            if(addResult)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("GetRandomFour")]
        public IActionResult GetRandomFour()
        {
            return Ok(_beforeAfterService.GetRandomFour());
        }
        [HttpGet("Get/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_beforeAfterService.GetById(id));
        }

        [HttpGet("All")]
        public IActionResult All()
        {
            return Ok(_beforeAfterService.All());
        }

        [HttpPost("Edit")]
        public IActionResult EditBeforeAfter(EditBeforeAfterVm beforeAfter)
        {
            _beforeAfterService.Update(beforeAfter);
            return Ok();
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            bool DelResult = _beforeAfterService.Delete(id);
            if (DelResult)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
