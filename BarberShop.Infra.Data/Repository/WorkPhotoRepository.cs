using BarberShop.Domain.Interfaces;
using BarberShop.Domain.Models;
using BarberShop.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Infra.Data.Repository
{
    public class WorkPhotoRepository : IWorkPhotoRepository
    {
        private readonly BarberShopContext _context;
        public WorkPhotoRepository(BarberShopContext context)
        {
            _context = context;
        }
        public bool Add(TblWorkPhoto workPhoto)
        {
            try
            {
                if(workPhoto != null)
                {
                    _context.TblWorkPhotos.Add(workPhoto);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<TblWorkPhoto> All()
        {
            var WorkPhotos = _context.TblWorkPhotos.AsEnumerable();
            return WorkPhotos;
        }

        public void Delete(int id)
        {
            TblWorkPhoto? workPhoto = _context.TblWorkPhotos.SingleOrDefault(i => i.Id == id);
            if (workPhoto != null)
            {
                _context.TblWorkPhotos.Remove(workPhoto);
                _context.SaveChanges();
            }
            else { return; }
        }

        public TblWorkPhoto GetById(int id)
        {
            TblWorkPhoto? workPhoto = _context.TblWorkPhotos.SingleOrDefault(i => i.Id == id);
            if (workPhoto != null)
            {
                return workPhoto;
            }
            else { return null; }
        }

        public void Update(TblWorkPhoto workPhoto)
        {
            try
            {
                TblWorkPhoto? WorkToEdit = _context.TblWorkPhotos.SingleOrDefault(i => i.Id == workPhoto.Id);
                if (WorkToEdit != null)
                {
                    if (workPhoto.ImageUrl != "")
                    {
                        WorkToEdit.ImageUrl = workPhoto.ImageUrl;
                    }
                    WorkToEdit.Title = workPhoto.Title;
                    _context.TblWorkPhotos.Update(WorkToEdit); _context.SaveChanges();
                }
                else
                {
                    return;
                }
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
