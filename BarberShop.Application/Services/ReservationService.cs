using AutoMapper;
using BarberShop.Application.Interfaces;
using BarberShop.Application.ViewModels.Reservation;
using BarberShop.Domain.Interfaces;
using BarberShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Application.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;
        public ReservationService(IReservationRepository reservationRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }

        public bool Add(CreateReservationVm reservation)
        {
            try
            {
                if(reservation != null)
                {
                    var reservationToAdd = _mapper.Map<TblReservation>(reservation);
                    _reservationRepository.Add(reservationToAdd);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<ReservationVm> Get(int id)
        {
            var reservation = await _reservationRepository.Get(id);
            return _mapper.Map<ReservationVm>(reservation);
        }

        public IEnumerable<ReservationListVm> GetByDate(DateOnly dateOnly)
        {
            var reserves = _reservationRepository.GetByDate(dateOnly);
            return _mapper.Map<IEnumerable<ReservationListVm>>(reserves);
        }

        public IEnumerable<ReservationListVm> GetByTimePeriod(DateOnly startDate, DateOnly endDate)
        {
            var reserves = _reservationRepository.GetByTimePeriod(startDate, endDate);
            return _mapper.Map<IEnumerable<ReservationListVm>>(reserves);
        }

        public bool Remove(int id)
        {
            return _reservationRepository.Remove(id);
        }

        public IEnumerable<ReservationTimeTableVm> ReservationHours(ReservationHoursVm reservationVm)
        {
            var reserveTimes = _reservationRepository.ReservationHours(reservationVm.Date, reservationVm.IntervalTime, reservationVm.ServiceId, reservationVm.HairStylist);
            return _mapper.Map<IEnumerable<ReservationTimeTableVm>>(reserveTimes);
        }

        public void Update(EditReservationVm reservation)
        {

            var ToUpdate = _mapper.Map<TblReservation>(reservation);
            _reservationRepository.Update(ToUpdate);
            
        }
    }
}
