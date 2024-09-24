using BarberShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Domain.Interfaces
{
    public interface IWorkPhotoRepository
    {
        bool Add(TblWorkPhoto workPhoto);
        IEnumerable<TblWorkPhoto> All();
        TblWorkPhoto GetById(int id);
        void Update(TblWorkPhoto workPhoto);
        void Delete(int id);
    }
}
