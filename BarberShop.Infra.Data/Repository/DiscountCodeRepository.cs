using BarberShop.Domain.Interfaces;
using BarberShop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarberShop.Application.Helper;
using BarberShop.Infra.Data.Context;

namespace BarberShop.Infra.Data.Repository
{
    public class DiscountCodeRepository : IDiscountCodeRepository
    {
        private readonly BarberShopContext _context;
        public DiscountCodeRepository(BarberShopContext context)
        {
            _context = context;
        }
        public bool Add(TblDiscountCode discountCode)
        {
            try
            {
                if (discountCode is not null)
                {
                    _context.TblDiscountCodes.Add(discountCode);
                    _context.SaveChanges();
                    return true;
                }
                else { return false; }
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<TblDiscountCode> All()
        {
            try
            {
                var Allcodes = _context.TblDiscountCodes.AsEnumerable();
                if (Allcodes.Count() > 0)
                {
                    return Allcodes;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public bool Delete(int id)
        {
            TblDiscountCode? DiscodeToDel = _context.TblDiscountCodes.SingleOrDefault(i => i.Id == id);
            if (DiscodeToDel is not null)
            {
                _context.TblDiscountCodes.Remove(DiscodeToDel);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public TblDiscountCode GetById(int id)
        {
            TblDiscountCode? discountCode = _context.TblDiscountCodes.SingleOrDefault(i => i.Id == id);
            if (discountCode is not null)
            {
                return discountCode;
            }
            else
            {
                return null;
            }
        }

        public async void Update(TblDiscountCode discountCode)
        {
            TblDiscountCode? disCode = await _context.TblDiscountCodes.SingleOrDefaultAsync(i => i.Id == discountCode.Id);
            if (discountCode is not null)
            {
                disCode.Code = discountCode.Code.Trim().ToString();
                disCode.DiscountPercent = discountCode.DiscountPercent;
                _context.Update(disCode);
                await _context.SaveChangesAsync();
            }
            return;
        }

        public string ValidateDisCode(string code, string price)
        {
            TblDiscountCode? DiscountCode = _context.TblDiscountCodes.SingleOrDefault(i => i.Code == code.Trim());
            if(DiscountCode is not null)
            {
                int Originalprice = DateUtils.ConvertToInteger(price);
                int percentComplete = (Originalprice * DiscountCode.DiscountPercent) / 100;
                string priceToShow = (Originalprice - percentComplete).ToString("##,##", new NumberFormatInfo() { NumberGroupSeparator = "," }) + " تومان";
                return priceToShow;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
