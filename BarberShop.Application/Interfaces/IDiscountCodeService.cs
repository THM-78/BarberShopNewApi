using BarberShop.Application.ViewModels.DiscountCode;
using BarberShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Application.Interfaces
{
    public interface IDiscountCodeService
    {
        bool Add(CreateDisCodeVm code);
        DisCodeVm GetById(int id);
        string ValidateDisCode(ValidateDisCodeVm disCodeVm);
        IEnumerable<DisCodeListVm> All();
        void Update(EditDisCodeVm discountCode);
        bool Delete(int id);
    }
}
