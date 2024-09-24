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
    public class InfoRepository : IinfoRepository
    {
        private readonly BarberShopContext _context;
        public InfoRepository(BarberShopContext context)
        {
            _context = context;
        }
        public TblBarbershopInfo GetById(int id)
        {
            TblBarbershopInfo? barbershopInfo = _context.TblBarbershopInfos.SingleOrDefault(i => i.Id == id);
            if (barbershopInfo != null)
            {
                return barbershopInfo;
            }
            return null;
        }

        public TblBarbershopInfo GetByInfo()
        {
            TblBarbershopInfo? barbershopInfo = _context.TblBarbershopInfos.FirstOrDefault();
            if (barbershopInfo != null)
            {
                return barbershopInfo;
            }
            else
            {
                return null;
            }
        }

        public void Update(TblBarbershopInfo barbershopInfo)
        {
            TblBarbershopInfo? InfoToEdit = _context.TblBarbershopInfos.SingleOrDefault(i => i.Id == barbershopInfo.Id);
            if (InfoToEdit != null)
            {
                InfoToEdit.Address = barbershopInfo.Address;
                InfoToEdit.PhoneNumber = barbershopInfo.PhoneNumber;
                InfoToEdit.InstaPage = barbershopInfo.InstaPage;
                _context.TblBarbershopInfos.Update(InfoToEdit);
                _context.SaveChanges();
            }
            else
            {
                return;
            }
        }
    }
}
