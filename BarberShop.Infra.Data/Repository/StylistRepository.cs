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
    public class StylistRepository : IStylistRepository
    {
        private readonly BarberShopContext _context;
        public StylistRepository(BarberShopContext context)
        {
            _context = context;
        }
        public bool Add(TblHairStylist hairStylist)
        {
            try
            {
                TblHairStylistLevel? hairStylistLevel = _context.TblHairStylistLevels.SingleOrDefault(i => i.Id == hairStylist.HairStylistLevelId);
                if (hairStylistLevel != null)
                {
                    _context.TblHairStylists.Add(hairStylist);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
            
        }

        public IEnumerable<TblHairStylist> All()
        {
            try
            {
                var AllStylists = _context.TblHairStylists.ToList().AsEnumerable();
                return AllStylists;
            }
            catch
            {
                return null;
            }
        }

        public bool Delete(int id)
        {
            TblHairStylist? hairStylist = _context.TblHairStylists.SingleOrDefault(i => i.Id == id);
            try
            {
                _context.TblHairStylists.Remove(hairStylist);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public TblHairStylist Get(int id)
        {
            try
            {
                var stylist =  _context.TblHairStylists.SingleOrDefault(i => i.Id == id);
                return stylist;
            }
            catch(Exception ex)
            {
                throw new Exception("خطای داخلی سرور", ex);
            }
        }

        public IEnumerable<TblHairStylist> GetAdminStylistByServiceId(int serviceId)
        {
            try
            {
                var stylistToTake = _context.TblServicePriceRels.Where(i => i.ServiceId == serviceId).Select(i => i.HairStylistId);
                var result = _context.TblHairStylists.Where(i => !stylistToTake.Any(x => x == i.Id )).ToList().AsEnumerable();
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception("خطای داخلی سرور", ex);
            }

        }

        public void Update(TblHairStylist hairStylist)
        {
            TblHairStylist? hairStylistToEdit = _context.TblHairStylists.Find(hairStylist.Id);
            if (hairStylistToEdit != null)
            {
                hairStylistToEdit.Name = hairStylist.Name;
                hairStylistToEdit.ImageUrl = hairStylist.ImageUrl;
                hairStylistToEdit.HairStylistLevelId = hairStylist.HairStylistLevelId;
                _context.TblHairStylists.Update(hairStylist);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
