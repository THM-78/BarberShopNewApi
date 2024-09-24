using BarberShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Application.ViewModels.Suggestion
{
    public class SuggestionListVm
    {
        public IEnumerable<TblSuggestion> Suggestions { get; set; }
        public long PageCount { get; set; }
    }
}
