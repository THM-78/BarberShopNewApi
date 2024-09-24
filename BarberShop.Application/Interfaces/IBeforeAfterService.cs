using BarberShop.Application.ViewModels.BeforeAfterImg;
using BarberShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Application.Interfaces
{
    public interface IBeforeAfterService
    {
        bool Add(CreateBeforeAfterVm beforeAfter);
        IEnumerable<BeforeAfterListVm> GetRandomFour();
        BeforeAfterVm GetById(int id);
        IEnumerable<BeforeAfterListVm> All();
        void Update(EditBeforeAfterVm beforeAfter);
        bool Delete(int id);
    }
}
