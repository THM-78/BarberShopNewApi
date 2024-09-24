using Azure;
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
    public class SuggestionRepository : ISuggestionRepostory
    {
        private readonly BarberShopContext _context;
        public SuggestionRepository(BarberShopContext context)
        {
            _context = context;
        }
        public void Add(TblSuggestion suggestion)
        {
            if (suggestion != null)
            {
                _context.TblSuggestions.Add(suggestion);
                _context.SaveChanges();
            }
            else
            {
                return;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                TblSuggestion? suggestion = _context.TblSuggestions.SingleOrDefault(i => i.Id == id);
                if (suggestion != null)
                {
                    _context.TblSuggestions.Remove(suggestion);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public TblSuggestion Get(int id)
        {
            TblSuggestion? suggestion = _context.TblSuggestions.SingleOrDefault(i => i.Id == id);
#pragma warning disable CS8603 // Possible null reference return.
            return suggestion;
#pragma warning restore CS8603 // Possible null reference return.
        }

        public IEnumerable<TblSuggestion> GetAllByPageNo(int pageNo)
        {
            List<TblSuggestion> SelectedSuggestion = _context.TblSuggestions.Skip(pageNo *20 - 20).Take(20).ToList();
            if (SelectedSuggestion.Count > 0)
            {
                //double PageCount = Math.Ceiling((double)suggestions.Count / 20);
                return SelectedSuggestion;

            }
            else
            {
                return null;
            }
        }

        public long GetAllCount()
        {
            try
            {
                long Suggestions = _context.TblSuggestions.Count();
                if (Suggestions > 0)
                {
                    return Suggestions;

                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        public string SuggestionTextById(int id)
        {
            TblSuggestion? suggestion = _context.TblSuggestions.SingleOrDefault(i => i.Id == id);
            if (suggestion != null)
            {
                string SuggestionMessage = suggestion.Message;
                return SuggestionMessage;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
