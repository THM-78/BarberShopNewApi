using BarberShop.Application.Helper;
using BarberShop.Domain.Interfaces;
using BarberShop.Domain.Models;
using BarberShop.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Infra.Data.Repository
{
    public class ReservationRepository : IReservationRepository 
    {
        private readonly BarberShopContext _context;
        public ReservationRepository(BarberShopContext context)
        {
            _context = context;
        }
        public bool Add(TblReservation reservation)
        {
            if(reservation == null)
            {
                //throw new ArgumentNullException(nameof(reservation))
                return false;
            }
            _context.TblReservations.Add(reservation);
            _context.SaveChanges();
            return true;
        }

        public async Task<TblReservation> Get(int id)
        {
            try
            {
                var Reservation = await _context.TblReservations.FindAsync(id);
                if (Reservation == null)
                    throw new ArgumentNullException();
                return Reservation;
            }
            catch(Exception ex)
            {
                throw new Exception("خطای داخلی سرور", ex);
            }
        }

        public IEnumerable<TblReservation> GetByDate(DateOnly dateOnly)
        {
            try
            {
                var Reserves = _context.TblReservations.Where(i => i.ReserveDate.Equals(dateOnly)).AsEnumerable();
                if(Reserves.Count() == 0)
                {
                    throw new NullReferenceException();
                }
                return Reserves;
            }
            catch(Exception ex)
            {
                throw new Exception("خطای داخلی سرور", ex);
            }
        }

        public IEnumerable<TblReservation> GetByTimePeriod(DateOnly startDate, DateOnly endDate)
        {
            try
            {
                var Reserves = _context.TblReservations.Where(i => DateOnly.FromDateTime(i.ReserveDate.Date) >= startDate)
                .Where(i => DateOnly.FromDateTime(i.ReserveDate.Date) <= endDate)
                .AsEnumerable();
                if (Reserves.Count() == 0)
                {
                    throw new NullReferenceException();
                }
                else
                return Reserves;
            }
            catch (Exception ex)
            {
                throw new Exception("خطای داخلی سرور", ex);
            }

        }

        public bool Remove(int id)
        {
            var Todelete = _context.TblReservations.Find(id);
            if(Todelete == null)
                return false;

            Todelete.IsReserved = false;
            _context.TblReservations.Update(Todelete);
            _context.SaveChanges();
            return true;
        }

        //struct ForFilloutTable
        //{
        //    public string Time { get; set; }
        //    public bool IsReserved { get; set; }
        //}
        public IEnumerable<TblReservation> ReservationHours(string Date, int IntervalTime, int ServiceId, string HairStylist)
        {
            List<TblReservation> TimeTable = new List<TblReservation>();
            DateTime date = DateUtils.ConvertToDate(Date);
            List<TblReservation> datesReserved = _context.TblReservations.Where(i => i.ReserveDate.Date == date.Date).ToList();


            List<DateTime> timeList = DateUtils.GenerateTimeList(date, new TimeSpan(9, 0, 0), new TimeSpan(20, 0, 0), new TimeSpan(0, IntervalTime, 0));
            foreach (DateTime time in timeList)
            {
                TblReservation p = new TblReservation();
                if (datesReserved.Any(i => i.ReserveDate.Hour == time.Hour))
                {
                    DateTime StartTime = new(date.Year, date.Month, date.Day, time.Hour, time.Minute, 0);
                    DateTime TocheckStart = StartTime.AddMinutes(-IntervalTime);
                    DateTime endTime = StartTime.AddMinutes(IntervalTime);
                    List<int> interval = new();
                    var tbl = datesReserved.Where(i => i.ReserveDate.Hour == time.Hour || i.ReserveDate.Hour + 1 == time.Hour || i.ReserveDate.Hour - 1 == time.Hour).ToList();
                    foreach (var i in tbl)
                    {
                        if (i.ReserveDate > TocheckStart && i.ReserveDate < endTime || i.ReserveDate.AddMinutes((double)IntervalTime) > time)
                        {
                            if (i.ServicePriceRel.HairStylist.Name == HairStylist)
                            {
                                p.IsReserved = true;
                            }
                        }
                        else
                        {
                            p.IsReserved = false;
                        }
                    }
                }
                else
                {
                    p.IsReserved = false;
                }
                p.ReserveDate = time;
                TimeTable.Add(p);
            }
            return TimeTable;
        }

        public void Update(TblReservation reservation)
        {
            try
            {
                var ToUpdate = _context.TblReservations.Find(reservation.Id);
                if (ToUpdate != null)
                {
                    if(reservation.ReserveDate != null)
                        ToUpdate.ReserveDate= reservation.ReserveDate;

                    if(reservation.UserId.HasValue)
                        ToUpdate.UserId = reservation.UserId;

                    ToUpdate.IsReserved = reservation.IsReserved;
                    if(reservation.ServicePriceRel != null)
                        ToUpdate.ServicePriceRelId = reservation.ServicePriceRelId;

                    _context.TblReservations.Update(ToUpdate);
                    _context.SaveChanges();
                }

                return;
            }
            catch(Exception ex)
            {
                throw new Exception("خطای داخلی سرور", ex);
            }
        }
    }
}
