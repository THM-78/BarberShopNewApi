using BarberShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Domain.Interfaces
{
    public interface IDiscountCodeRepository
    {
        bool Add(TblDiscountCode code);
        TblDiscountCode GetById(int id);
        IEnumerable<TblDiscountCode> All();
        string ValidateDisCode(string code, string price);
        void Update(TblDiscountCode discountCode);
        bool Delete(int id);

    }
}
