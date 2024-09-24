using BarberShop.Application.ViewModels.HairStylist;
using BarberShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Application.Interfaces
{
    public interface IStylistService
    {
        bool Add(CreateHairStylistVm hairStylist);
        HairStylistVm Get(int id);
        IEnumerable<HairStylistListVm> All();
        IEnumerable<HairStylistListVm> GetAdminStylistByServiceId(int serviceId);
        void Update(EditHairStylistVm hairStylist);
        bool Delete(int id);
    }
}
