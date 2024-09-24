using BarberShop.Application.ViewModels.WorkPhoto;
using BarberShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Application.Interfaces
{
    public interface IWorkPhotoService
    {
        bool Add(CreateWorkPhotoVm workPhoto);
        IEnumerable<WorkPhotoListVm> All();
        WorkPhotoVm GetById(int id);
        void Update(EditWorkPhotoVm workPhoto);
        void Delete(int id);
    }
}
