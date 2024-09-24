using BarberShop.Domain.Interfaces;
using BarberShop.Domain.Models;
using BarberShop.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Infra.Data.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly BarberShopContext _context;
        public ServiceRepository(BarberShopContext context)
        {
            _context = context;
        }
        public bool Add(TblService service)
        {
            try
            {
                if (service != null)
                {
                    _context.TblServices.Add(service);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<TblService> All()
        {
            try
            {
                var all = _context.TblServices.AsEnumerable();
                if (all.Count() > 0)
                {
                
                    return all;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public bool Delete(int Id)
        {
            TblService? service = _context.TblServices.SingleOrDefault(i => i.Id == Id);
            if (service != null)
            {
                _context.TblServices.Remove(service);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public TblService GetById(int Id)
        {
            TblService? service = _context.TblServices.Find(Id);
            if (service is not null)
            {
                return service;
            }
            else
            {
                return null;
            }
        }

        public TblService GetByType(string type)
        {
            TblService? service = _context.TblServices.SingleOrDefault(i => i.Type == type);
            if (service != null)
            {
                return (TblService)service;
            }
            else
            {
                return null;
            }
        }

        public int GetIntervalTimeById(int Id)
        {
            TblService? service = _context.TblServices.Find(Id);
            if (service is not null)
            {
                int IntervalTime = (int)service.PeriodOfTime;
                return IntervalTime;
            }
            else
            {
                return 0;
            }
        }

        public IEnumerable<TblService> GetReservationServices()
        {
            var ReservationServices = _context.TblServices.Where(i => i.TblServicePriceRels.Count > 0).AsEnumerable();
            if (ReservationServices.Count() > 0)
            {
                return ReservationServices;
            }
            else
            {
                return null;
            }
        }

        public void Update(TblService service)
        {
            try
            {
                TblService? ServiceToEdit = _context.TblServices.SingleOrDefault(i => i.Id == service.Id);
                if (ServiceToEdit != null)
                {
                    ServiceToEdit.PeriodOfTime = service.PeriodOfTime;
                    ServiceToEdit.Type = service.Type;
                    _context.TblServices.Update(ServiceToEdit);
                    _context.SaveChanges();
                }
                else { throw new Exception(); }
            }
            catch
            {
                return;
            }
        }
    }
}
