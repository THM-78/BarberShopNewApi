using BarberShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Domain.Interfaces
{
    public interface ISuggestionRepostory
    {
        void Add(TblSuggestion suggestion);
        IEnumerable<TblSuggestion> GetAllByPageNo(int pageNo);
        long GetAllCount();
        TblSuggestion Get(int id);
        string SuggestionTextById(int id);
        bool Delete(int id);
    }
}
