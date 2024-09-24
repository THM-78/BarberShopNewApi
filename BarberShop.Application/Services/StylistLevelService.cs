using AutoMapper;
using BarberShop.Application.Interfaces;
using BarberShop.Application.ViewModels.HairStylistLevel;
using BarberShop.Domain.Interfaces;
using BarberShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Application.Services
{
    public class StylistLevelService : IStylistLevelService
    {
        private readonly IStylistLevelRepository _stylistLevelRepository;
        private readonly IMapper _mapper;
        public StylistLevelService(IStylistLevelRepository stylistLevelRepository, IMapper mapper)
        {
            _stylistLevelRepository = stylistLevelRepository;
            _mapper = mapper;
        }

        public bool Add(CreateStylistLevelVm hairStylistLevel)
        {
            var LevelToAdd = _mapper.Map<TblHairStylistLevel>(hairStylistLevel);
            return _stylistLevelRepository.Add(LevelToAdd);
        }

        public IEnumerable<StylistLevelListVm> All()
        {
            var levels = _stylistLevelRepository.All();
            return _mapper.Map<IEnumerable<StylistLevelListVm>>(levels);
        }

        public bool Delete(int id)
        {
            return _stylistLevelRepository.Delete(id);
        }

        public void Update(EditStylistLevelVm hairStylistLevel)
        {
            var levelToEdit = _mapper.Map<TblHairStylistLevel>(hairStylistLevel);
            _stylistLevelRepository.Update(levelToEdit);
        }
    }
}
