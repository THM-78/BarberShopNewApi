using BarberShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Domain.Interfaces
{
    public interface IStylistRepository
    {
        bool Add(TblHairStylist hairStylist);
        TblHairStylist Get(int id);
        IEnumerable<TblHairStylist> GetAdminStylistByServiceId(int serviceId);
        IEnumerable<TblHairStylist> All();
        void Update(TblHairStylist hairStylist);
        bool Delete(int id);
    }
}
