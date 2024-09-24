using BarberShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Domain.Interfaces
{
    public interface IBeforeAfterRepository
    {
        bool Add(TblBeforeAfter beforeAfter);
        IEnumerable<TblBeforeAfter> GetRandomFour();
        TblBeforeAfter GetById(int id);
        IEnumerable<TblBeforeAfter> All();
        void Update(TblBeforeAfter beforeAfter);
        bool Delete(int id);
    }
}
