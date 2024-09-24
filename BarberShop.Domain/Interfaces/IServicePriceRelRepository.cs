using BarberShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Domain.Interfaces
{
    public interface IServicePriceRelRepository
    {
        bool AddReservation(TblServicePriceRel servicePriceRel);
        string GetPrice(int ServiceId, int HairStylistId);
        TblServicePriceRel Get(int Id);
        void Update(TblServicePriceRel servicePriceRel);
        IEnumerable<TblServicePriceRel> All();
        IEnumerable<TblServicePriceRel> GetStylistByServiceId(int serviceId);
        bool RemoveReservation(int id);
    }
}
