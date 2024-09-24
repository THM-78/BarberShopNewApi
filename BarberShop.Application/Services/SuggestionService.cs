using AutoMapper;
using BarberShop.Application.Interfaces;
using BarberShop.Application.ViewModels.Suggestion;
using BarberShop.Domain.Interfaces;
using BarberShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarberShop.Application.Services
{
    public class SuggestionService : ISuggestionService
    {
        private readonly ISuggestionRepostory _suggestionRepostory;
        private readonly IMapper _mapper;
        public SuggestionService(ISuggestionRepostory suggestionRepostory, IMapper mapper)
        {
            _suggestionRepostory = suggestionRepostory;
            _mapper = mapper;
        }
        public void Add(CreateSuggestionVm suggestion)
        {
            var suggestionToAdd = _mapper.Map<TblSuggestion>(suggestion);
            _suggestionRepostory.Add(suggestionToAdd);
        }

        public bool Delete(int id)
        {
            return _suggestionRepostory.Delete(id);
        }

        public SuggestionVm Get(int id)
        {
            var suggestion = _suggestionRepostory.Get(id);
            return _mapper.Map<SuggestionVm>(suggestion);
        }

        public Task<SuggestionListVm> GetAllByPageNo(int pageNo)
        {
            var suggestions = _suggestionRepostory.GetAllByPageNo(pageNo);
            SuggestionListVm listVm = new()
            {
                Suggestions = suggestions,
                PageCount = GetAllCount()
            };
            return Task.FromResult(listVm);

        }

        public long GetAllCount()
        {
            return _suggestionRepostory.GetAllCount();
        }

        public string SuggestionTextById(int id)
        {
            return _suggestionRepostory.SuggestionTextById(id);
        }
    }
}
