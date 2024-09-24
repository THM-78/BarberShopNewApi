using AutoMapper;
using BarberShop.Application.Interfaces;
using BarberShop.Application.ViewModels.WorkPhoto;
using BarberShop.Domain.Interfaces;
using BarberShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Application.Services
{
    public class WorkPhotoService : IWorkPhotoService
    {
        private readonly IWorkPhotoRepository _workPhotoRepository;
        private readonly IMapper _mapper;
        public WorkPhotoService(IWorkPhotoRepository workPhotoRepository, IMapper mapper)
        {
            _workPhotoRepository = workPhotoRepository;
            _mapper = mapper;
        }

        public bool Add(CreateWorkPhotoVm workPhoto)
        {
            var PhotoToAdd = _mapper.Map<TblWorkPhoto>(workPhoto);
            return _workPhotoRepository.Add(PhotoToAdd);
        }

        public IEnumerable<WorkPhotoListVm> All()
        {
            var photos = _workPhotoRepository.All();
            return _mapper.Map<IEnumerable<WorkPhotoListVm>>(photos);
        }

        public void Delete(int id)
        {
            _workPhotoRepository.Delete(id);
        }

        public WorkPhotoVm GetById(int id)
        {
            var PhotoToShow = _workPhotoRepository.GetById(id);
            return _mapper.Map<WorkPhotoVm>(PhotoToShow);
        }

        public void Update(EditWorkPhotoVm workPhoto)
        {
            var PhotoToEdit = _mapper.Map<TblWorkPhoto>(workPhoto);
            _workPhotoRepository.Update(PhotoToEdit);
        }
    }
}
