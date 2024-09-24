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
    public class StylistLevelRepository : IStylistLevelRepository
    {
        private readonly BarberShopContext _context;
        public StylistLevelRepository(BarberShopContext context)
        {
            _context = context;
        }
        public bool Add(TblHairStylistLevel hairStylistLevel)
        {
            try
            {
                if (hairStylistLevel != null)
                {
                    _context.TblHairStylistLevels.Add(hairStylistLevel);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<TblHairStylistLevel> All()
        {
            var levels = _context.TblHairStylistLevels.AsEnumerable();
            if (levels.Count() != 0)
            {
                return levels;
            }
            return null;
        }

        public bool Delete(int id)
        {
            try
            {
                var level = _context.TblHairStylistLevels.SingleOrDefault(i => i.Id == id);
                _context.TblHairStylistLevels.Remove(level);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public void Update(TblHairStylistLevel hairStylistLevel)
        {
            var level = _context.TblHairStylistLevels.Find(hairStylistLevel.Id);
            if(level == null)
            {
                return;
            }
            level.StylistLevel = hairStylistLevel.StylistLevel;
            _context.TblHairStylistLevels.Update(level);
            _context.SaveChanges();
        }
    }
}
