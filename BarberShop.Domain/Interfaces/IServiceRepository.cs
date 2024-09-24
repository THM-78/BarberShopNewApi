using BarberShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Domain.Interfaces
{
    public interface IServiceRepository
    {
        bool Add(TblService service);
        TblService GetByType(string type);
        TblService GetById(int Id);
        int GetIntervalTimeById(int Id);
        IEnumerable<TblService> GetReservationServices();
        IEnumerable<TblService> All();
        void Update(TblService service);
        bool Delete(int Id);
    }
}
