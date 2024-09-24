using AutoMapper;
using BarberShop.Application.Interfaces;
using BarberShop.Application.ViewModels.BeforeAfterImg;
using BarberShop.Domain.Interfaces;
using BarberShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Application.Services
{
    public class BeforeAfterService : IBeforeAfterService
    {
        private readonly IBeforeAfterRepository _beforeAfterRepostory;
        private readonly IMapper _mapper;
        public BeforeAfterService(IBeforeAfterRepository beforeAfterRepostory, IMapper mapper)
        {
            _beforeAfterRepostory = beforeAfterRepostory;
            _mapper = mapper;
        }
        public bool Add(CreateBeforeAfterVm beforeAfter)
        {
            var ImgsToAdd = _mapper.Map<TblBeforeAfter>(beforeAfter);
            return _beforeAfterRepostory.Add(ImgsToAdd);
        }

        public IEnumerable<BeforeAfterListVm> All()
        {
            var Alllist = _beforeAfterRepostory.All();
            return _mapper.Map<IEnumerable<BeforeAfterListVm>>(Alllist);
        }

        public bool Delete(int id)
        {
            return _beforeAfterRepostory.Delete(id);
        }

        public BeforeAfterVm GetById(int id)
        {
            var Imgs = _beforeAfterRepostory.GetById(id);
            return _mapper.Map<BeforeAfterVm>(Imgs);
        }

        public IEnumerable<BeforeAfterListVm> GetRandomFour()
        {
            var Fourlist = _beforeAfterRepostory.GetRandomFour();
            return _mapper.Map<IEnumerable<BeforeAfterListVm>>(Fourlist);

        }

        public void Update(EditBeforeAfterVm beforeAfter)
        {
            TblBeforeAfter ImgsToEdit = _mapper.Map<TblBeforeAfter>(beforeAfter);
            _beforeAfterRepostory.Update(ImgsToEdit);
        }
    }
}
