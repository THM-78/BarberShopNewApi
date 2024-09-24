using BarberShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Domain.Interfaces
{
    public interface IReservationRepository
    {
        bool Add(TblReservation reservation);
        Task<TblReservation> Get(int id);
        IEnumerable<TblReservation> ReservationHours(string Date, int IntervalTime, int ServiceId, string HairStylist);
        IEnumerable<TblReservation> GetByDate(DateOnly dateOnly);
        IEnumerable<TblReservation> GetByTimePeriod(DateOnly startDate, DateOnly endDate);
        void Update(TblReservation reservation);
        bool Remove(int id);
    }
}
