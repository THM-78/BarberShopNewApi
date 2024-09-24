using BarberShop.Application.Interfaces;
using BarberShop.Application.ViewModels.Suggestion;
using BarberShop.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuggestionController : ControllerBase
    {
        private readonly ISuggestionService _suggestionService;
        public SuggestionController(ISuggestionService suggestionService)
        {
            _suggestionService = suggestionService;
        }

        [HttpPost("AddSuggestion")]
        public IActionResult AddSuggestion(CreateSuggestionVm suggestion)
        {
            _suggestionService.Add(suggestion);
            return Ok();
        }

        [HttpGet("AllSuggestion/{pageNo}")]
        public IActionResult AllSuggestion(int pageNo)
        {
            var result = _suggestionService.GetAllByPageNo(pageNo);
            return Ok(result);

        }


        [HttpGet("SuggestionTextById/{id}")]
        public IActionResult SuggestionTextById(int id)
        {
            var result = _suggestionService.SuggestionTextById(id);
            if (result == null)
                return BadRequest();
            return Ok(result);  
        }


        [HttpDelete("DelSuggestion/{id}")]
        public IActionResult DelSuggestion(int id)
        {
            bool result = _suggestionService.Delete(id);
            if (result)
                return Ok();
            return BadRequest();
        }
    }
}
