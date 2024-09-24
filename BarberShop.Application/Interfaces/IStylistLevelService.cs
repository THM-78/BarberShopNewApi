using BarberShop.Application.ViewModels.HairStylist;
using BarberShop.Application.ViewModels.HairStylistLevel;
using BarberShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Application.Interfaces
{
    public interface IStylistLevelService
    {
        bool Add(CreateStylistLevelVm hairStylistLevel);
        IEnumerable<StylistLevelListVm> All();
        void Update(EditStylistLevelVm hairStylistLevel);
        bool Delete(int id);
    }
}
