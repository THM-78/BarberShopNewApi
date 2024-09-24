using AutoMapper;
using BarberShop.Application.Interfaces;
using BarberShop.Application.ViewModels.ServicePriceRel;
using BarberShop.Domain.Interfaces;
using BarberShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Application.Services
{
    public class ServicePriceRelService : IServicePriceRelService
    {
        private readonly IServicePriceRelRepository _servicePriceRelRepository;
        private readonly IMapper _mapper;
        public ServicePriceRelService(IServicePriceRelRepository servicePriceRelRepository, IMapper mapper)
        {
            _servicePriceRelRepository = servicePriceRelRepository;
            _mapper = mapper;
        }

        public bool AddReservation(CreateServicePriceVm servicePriceRel)
        {
            var toAdd = _mapper.Map<TblServicePriceRel>(servicePriceRel);
            return _servicePriceRelRepository.AddReservation(toAdd);
        }

        public IEnumerable<ServicePriceListVm> All()
        {
            var result = _servicePriceRelRepository.All();
            return _mapper.Map<IEnumerable<ServicePriceListVm>>(result);
        }

        public ServicePriceVm Get(int Id)
        {
            var servicePrice = _servicePriceRelRepository.Get(Id);
            return _mapper.Map<ServicePriceVm>(servicePrice);
        }

        public string GetPrice(PriceVm priceVm)
        {
            string price = _servicePriceRelRepository.GetPrice(priceVm.ServiceId, priceVm.HairStylistId);
            return price;
        }

        public IEnumerable<ReservationStylistListVm> GetStylistByServiceId(int serviceId)
        {
            var Reservations = _servicePriceRelRepository.GetStylistByServiceId(serviceId);
            return _mapper.Map<IEnumerable<ReservationStylistListVm>>(Reservations);
        }

        public bool RemoveReservation(int id)
        {
            return _servicePriceRelRepository.RemoveReservation(id);
        }

        public void Update(EditServicePriceVm servicePrice)
        {
            var toEdit = _mapper.Map<TblServicePriceRel>(servicePrice);
            _servicePriceRelRepository.Update(toEdit);
        }
    }
}
