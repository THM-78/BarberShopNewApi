using BarberShop.Application.ViewModels.Service;
using BarberShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Application.Interfaces
{
    public interface IServiceService
    {
        bool Add(CreateServiceVm service);
        ServiceVm GetByType(string type);
        ServiceVm GetById(int Id);
        int GetIntervalTimeById(int Id);
        IEnumerable<ServiceListVm> GetReservationServices();
        IEnumerable<ServiceListVm> All();
        void Update(EditServiceVm service);
        bool Delete(int Id);
    }
}
