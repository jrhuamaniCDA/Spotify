using System.Collections.Generic;
using Spotify.Domain.Enums;
using Spotify.Domain.Interfaces;
using Spotify.Domain.Response;

namespace Spotify.Application
{
    public class SearchBusiness : ISearchBusiness
    {
        private ISearchService _searchService { get; set; }
        public SearchBusiness(ISearchService searchBusiness)
        {
            _searchService = searchBusiness;
        }
        public List<Artist> Search(string name, SearchEnum type)
        {
            var responseService = _searchService.Search(name, type.ToString());

            //...

            return new List<Artist>();
        }
    }
}
