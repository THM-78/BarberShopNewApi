using BarberShop.Application.Interfaces;
using BarberShop.Application.ViewModels.Reservation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BarberShop.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost("Add")]
        public IActionResult AddReservation(CreateReservationVm Reservation)
        {
            bool AddResult = _reservationService.Add(Reservation);
            if (AddResult)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("ReservationHours")]
        public IActionResult ReservationHours(ReservationHoursVm reservationVm)
        {
            try
            {
                return Ok(_reservationService.ReservationHours(reservationVm));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Get/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_reservationService.Get(id));
        }

        [HttpGet("GetByDate")]
        public IActionResult GetByDate(DateOnly date)
        {
            return Ok(_reservationService.GetByDate(date));
        }

        [HttpGet("GetByTimePeriod")]
        public IActionResult GetByTimePeriod(DateOnly startDate, DateOnly endDate)
        {
            return Ok(_reservationService.GetByTimePeriod(startDate, endDate));
        }

        [HttpPost("Edit")]
        public IActionResult EditReservation(EditReservationVm reservation)
        {
            try
            {
                _reservationService.Update(reservation);
                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode( 500,ex.Message);
            }
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteReservation(int id)
        {
            bool delResult = _reservationService.Remove(id);
            if (delResult)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
