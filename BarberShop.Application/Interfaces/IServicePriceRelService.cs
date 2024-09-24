using BarberShop.Application.ViewModels.ServicePriceRel;
using BarberShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Application.Interfaces
{
    public interface IServicePriceRelService
    {
        bool AddReservation(CreateServicePriceVm servicePriceRel);
        string GetPrice(PriceVm priceVm);
        IEnumerable<ServicePriceListVm> All();
        IEnumerable<ReservationStylistListVm> GetStylistByServiceId(int serviceId);
        ServicePriceVm Get(int Id);
        void Update(EditServicePriceVm servicePrice);
        bool RemoveReservation(int id);
    }
}
