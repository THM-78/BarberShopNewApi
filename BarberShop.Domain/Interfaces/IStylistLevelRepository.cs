using BarberShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Domain.Interfaces
{
    public interface IStylistLevelRepository
    {
        bool Add(TblHairStylistLevel hairStylistLevel);
        IEnumerable<TblHairStylistLevel> All();
        void Update(TblHairStylistLevel hairStylistLevel);
        bool Delete(int id);
    }
}
