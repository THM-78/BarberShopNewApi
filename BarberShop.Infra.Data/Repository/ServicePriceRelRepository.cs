using BarberShop.Application.ViewModels.HairStylist;
using BarberShop.Application.ViewModels.Service;
using BarberShop.Domain.Interfaces;
using BarberShop.Domain.Models;
using BarberShop.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Infra.Data.Repository
{
    public class ServicePriceRelRepository : IServicePriceRelRepository
    {
        private readonly BarberShopContext _context;
        public ServicePriceRelRepository(BarberShopContext context)
        {
            _context = context;
        }
        public bool AddReservation(TblServicePriceRel servicePriceRel)
        {
            try
            {
                if(servicePriceRel == null)
                {
                    return false;
                }
                _context.TblServicePriceRels.Add(servicePriceRel);
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<TblServicePriceRel> All()
        {
            try
            {
                var servicePriceRels = _context.TblServicePriceRels.ToList().AsEnumerable();
                if (servicePriceRels.Count() > 0)
                {
                    return servicePriceRels;
                }
                return null;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                return null;
            }
        }

        public TblServicePriceRel Get(int Id)
        {
            TblServicePriceRel? priceRel = _context.TblServicePriceRels.SingleOrDefault(i => i.Id == Id);
            if (priceRel != null)
            {
                return priceRel;

            }
            else
            {
                throw new InvalidOperationException("یافت نشد.");
            }
        }

        public string GetPrice(int ServiceId, int HairStylistId)
        {
            TblServicePriceRel? priceRel = _context.TblServicePriceRels.SingleOrDefault(i => i.ServiceId == ServiceId && i.HairStylistId == HairStylistId);
            if (priceRel != null)
            {
                string pricee = priceRel.Price.Value.ToString("##,##", new NumberFormatInfo() { NumberGroupSeparator = "," }) + " تومان";
                string price = String.Format("{0:#,##} تومان", priceRel.Price);
                return price;

            }
            else
            {
                throw new InvalidOperationException("قیمت برای این سرویس و آرایشگر یافت نشد.");
            }
        }

        public IEnumerable<TblServicePriceRel> GetStylistByServiceId(int serviceId)
        {
            try
            {
                var servicePriceRel = _context.TblServicePriceRels.Where(i => i.ServiceId == serviceId).ToList().AsEnumerable();
                if(servicePriceRel.Count() > 0)
                {
                    return servicePriceRel;
                }
                return null;
            }
            catch(Exception ex)
            {
                string err = ex.Message;
                return null;
            }
            
        }

        public bool RemoveReservation(int id)
        {
            var serviceToDelete = _context.TblServicePriceRels.SingleOrDefault(i => i.Id == id);
            if(serviceToDelete == null)
            {
                return false;
            }
            _context.TblServicePriceRels.Remove(serviceToDelete);
            _context.SaveChanges();
            return true;
        }

        public void Update(TblServicePriceRel servicePriceRel)
        {
            try
            {

                var servicePriceToEdit = _context.TblServicePriceRels.SingleOrDefault(i => i.Id == servicePriceRel.Id);
                if(servicePriceToEdit.Price.HasValue)
                {
                    //servicePriceToEdit.ServiceId = servicePriceRel.Id;
                    //servicePriceToEdit.HairStylistId = servicePriceRel.HairStylistId;
                    if(servicePriceToEdit.Price == servicePriceRel.Price)
                    {
                        return;
                    }
                    servicePriceToEdit.Price = servicePriceRel.Price;
                    _context.TblServicePriceRels.Update(servicePriceToEdit);
                    _context.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException("یافت نشد");
                }
            }
            catch(Exception ex)
            {
                throw new InvalidOperationException("خطای سرور");
            }
        }
    }
}
