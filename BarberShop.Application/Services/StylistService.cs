using AutoMapper;
using BarberShop.Application.Interfaces;
using BarberShop.Application.ViewModels.HairStylist;
using BarberShop.Domain.Interfaces;
using BarberShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Application.Services
{
    public class StylistService : IStylistService
    {
        private readonly IStylistRepository _stylistRepository;
        private readonly IMapper _mapper;
        public StylistService(IStylistRepository stylistRepository, IMapper mapper)
        {
            _stylistRepository = stylistRepository;
            _mapper = mapper;
        }

        public bool Add(CreateHairStylistVm hairStylist)
        {
            var StylistToAdd = _mapper.Map<TblHairStylist>(hairStylist);
            return _stylistRepository.Add(StylistToAdd);
        }

        public IEnumerable<HairStylistListVm> All()
        {
            IEnumerable<TblHairStylist> stylists = _stylistRepository.All();
            return _mapper.Map<IEnumerable<HairStylistListVm>>(stylists);
        }

        public bool Delete(int id)
        {
            return _stylistRepository.Delete(id);
        }

        public HairStylistVm Get(int id)
        {
            var stylist = _stylistRepository.Get(id);
            return _mapper.Map<HairStylistVm>(stylist);
        }

        public IEnumerable<HairStylistListVm> GetAdminStylistByServiceId(int serviceId)
        {
            var result = _stylistRepository.GetAdminStylistByServiceId(serviceId);
            return _mapper.Map<IEnumerable<HairStylistListVm>>(result);
        }

        public void Update(EditHairStylistVm hairStylist)
        {
            var stylistToEdit = _mapper.Map<TblHairStylist>(hairStylist);
            _stylistRepository.Update(stylistToEdit);
        }
    }
}
