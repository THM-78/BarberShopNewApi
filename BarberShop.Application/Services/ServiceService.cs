using AutoMapper;
using BarberShop.Application.Interfaces;
using BarberShop.Application.ViewModels.Service;
using BarberShop.Domain.Interfaces;
using BarberShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Application.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IMapper _mapper;
        public ServiceService(IServiceRepository serviceRepository, IMapper mapper)
        {
            _serviceRepository = serviceRepository;
            _mapper = mapper;
        }
        public bool Add(CreateServiceVm service)
        {
            var ServiceToAdd = _mapper.Map<TblService>(service);
            return _serviceRepository.Add(ServiceToAdd);
        }

        public IEnumerable<ServiceListVm> All()
        {
            var services = _serviceRepository.All();
            return _mapper.Map<IEnumerable<ServiceListVm>>(services);
        }

        public bool Delete(int Id)
        {
            return _serviceRepository.Delete(Id);
        }

        public ServiceVm GetById(int Id)
        {
            var service = _serviceRepository.GetById(Id);
            return _mapper.Map<ServiceVm>(service);
        }

        public ServiceVm GetByType(string type)
        {
            var service = _serviceRepository.GetByType(type);
            return _mapper.Map<ServiceVm>(service);
        }

        public int GetIntervalTimeById(int Id)
        {
            return _serviceRepository.GetIntervalTimeById(Id);
        }

        public IEnumerable<ServiceListVm> GetReservationServices()
        {
            var serivces = _serviceRepository.GetReservationServices();
            return _mapper.Map<IEnumerable<ServiceListVm>>(serivces);
        }

        public void Update(EditServiceVm service)
        {
            var serviceToEdit = _mapper.Map<TblService>(service);
            _serviceRepository.Update(serviceToEdit);
        }
    }
}
