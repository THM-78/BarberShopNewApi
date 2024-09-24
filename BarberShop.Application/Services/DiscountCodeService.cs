using AutoMapper;
using BarberShop.Application.Interfaces;
using BarberShop.Application.ViewModels.DiscountCode;
using BarberShop.Domain.Interfaces;
using BarberShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Application.Services
{
    public class DiscountCodeService : IDiscountCodeService
    {

        private readonly IDiscountCodeRepository _discountCodeRepository;
        private readonly IMapper _mapper;
        public DiscountCodeService(IDiscountCodeRepository discountCodeRepository, IMapper mapper)
        {
            _discountCodeRepository = discountCodeRepository;
            _mapper = mapper;
        }

        public bool Add(CreateDisCodeVm code)
        {
            var disCodeToAdd = _mapper.Map<TblDiscountCode>(code);
            return _discountCodeRepository.Add(disCodeToAdd);
        }

        public IEnumerable<DisCodeListVm> All()
        {
            var disCodes = _discountCodeRepository.All();
            return _mapper.Map<IEnumerable<DisCodeListVm>>(disCodes);
        }

        public bool Delete(int id)
        {
            return _discountCodeRepository.Delete(id);
        }

        public DisCodeVm GetById(int id)
        {
            var discode = _discountCodeRepository.GetById(id);
            return _mapper.Map<DisCodeVm>(discode); 
        }

        public void Update(EditDisCodeVm discountCode)
        {
            var DisCodeToEdit = _mapper.Map<TblDiscountCode>(discountCode);
            _discountCodeRepository.Update(DisCodeToEdit);
        }

        public string ValidateDisCode(ValidateDisCodeVm disCodeVm)
        {
            return _discountCodeRepository.ValidateDisCode(disCodeVm.Code, disCodeVm.Price);
        }
    }
}
