using BarberShop.Application.ViewModels.Suggestion;
using BarberShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Application.Interfaces
{
    public interface ISuggestionService
    {
        void Add(CreateSuggestionVm suggestion);
        Task<SuggestionListVm> GetAllByPageNo(int pageNo);
        long GetAllCount();
        SuggestionVm Get(int id);
        string SuggestionTextById(int id);
        bool Delete(int id);
    }
}
