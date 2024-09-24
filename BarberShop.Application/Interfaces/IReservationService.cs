using BarberShop.Application.ViewModels.Reservation;
using BarberShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Application.Interfaces
{
    public interface IReservationService
    {
        bool Add(CreateReservationVm reservation);
        Task<ReservationVm> Get(int id);
        IEnumerable<ReservationTimeTableVm> ReservationHours(ReservationHoursVm reservationVm);
        IEnumerable<ReservationListVm> GetByDate(DateOnly dateOnly);
        IEnumerable<ReservationListVm> GetByTimePeriod(DateOnly startDate, DateOnly endDate);
        void Update(EditReservationVm reservation);
        bool Remove(int id);
    }
}
