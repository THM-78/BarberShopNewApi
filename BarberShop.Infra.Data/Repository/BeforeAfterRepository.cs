using BarberShop.Domain.Interfaces;
using BarberShop.Domain.Models;
using BarberShop.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Infra.Data.Repository
{
    public class BeforeAfterRepository : IBeforeAfterRepository
    {
        private readonly BarberShopContext _context;
        public BeforeAfterRepository(BarberShopContext context)
        {
            _context = context;
        }
        public bool Add(TblBeforeAfter beforeAfter)
        {
            try
            {
                _context.TblBeforeAfters.Add(beforeAfter);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<TblBeforeAfter> All()
        {
            IEnumerable<TblBeforeAfter> AllbeforeAfters = _context.TblBeforeAfters.AsEnumerable();
            return AllbeforeAfters;
        }
        public TblBeforeAfter GetById(int Id)
        {
            var BeforeAfter = _context.TblBeforeAfters.Find(Id);
            if(BeforeAfter != null)
            {
                return BeforeAfter;
            }
            throw new ArgumentNullException("یافت نشد");
        }

        public bool Delete(int id)
        {
            try
            {
                TblBeforeAfter? beforeAfterToDel = _context.TblBeforeAfters.SingleOrDefault(i => i.Id == id);
                _context.TblBeforeAfters.Remove(beforeAfterToDel);
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }

        }


        public IEnumerable<TblBeforeAfter> GetRandomFour()
        {
            var beforeAfters = _context.TblBeforeAfters.ToList();
            var SelectToDisplay = new List<TblBeforeAfter>();
            Random random = new Random();

            while (SelectToDisplay.Count < 4)
            {
                int index = random.Next(beforeAfters.Count);
                SelectToDisplay.Add(beforeAfters[index]);
            }
            return SelectToDisplay.AsEnumerable();
        }

        public void Update(TblBeforeAfter beforeAfter)
        {
            TblBeforeAfter? BeforeAfterToEdit = _context.TblBeforeAfters.SingleOrDefault(i => i.Id == beforeAfter.Id);
            if (BeforeAfterToEdit != null)
            {
                BeforeAfterToEdit.BeforeImgUrl = beforeAfter.BeforeImgUrl;
                BeforeAfterToEdit.AfterImgUrl = beforeAfter.AfterImgUrl;
                _context.TblBeforeAfters.Update(BeforeAfterToEdit); _context.SaveChanges();
            }
            else
            {
                return;
            }
        }
    }
}
