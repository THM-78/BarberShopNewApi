using BarberShop.Application.Interfaces;
using BarberShop.Domain.Interfaces;
using BarberShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Application.Services
{
    public class BarberShopInfoService : IinfoService
    {
        private readonly IinfoRepository _infoRepository;
        public BarberShopInfoService(IinfoRepository infoRepository)
        {
            _infoRepository = infoRepository;
        }
        public TblBarbershopInfo GetById(int id)
        {
            return _infoRepository.GetById(id);
        }

        public TblBarbershopInfo GetByInfo()
        {
            return _infoRepository.GetByInfo();
        }

        public void Update(TblBarbershopInfo info)
        {
            _infoRepository.Update(info);
        }
    }
}
