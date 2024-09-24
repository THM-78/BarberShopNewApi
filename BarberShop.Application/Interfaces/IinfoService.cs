using BarberShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Application.Interfaces
{
    public interface IinfoService
    {
        TblBarbershopInfo GetByInfo();
        TblBarbershopInfo GetById(int id);
        void Update(TblBarbershopInfo info);
    }
}
