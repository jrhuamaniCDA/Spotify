using System.Collections.Generic;
using Spotify.Domain.Enums;
using Spotify.Domain.Response;
using Spotify.Service;

namespace Spotify.Application
{
    public class SearchBusiness //: ISearchBusiness
    {
        private SearchService _searchService { get; set; }
        public SearchBusiness()
        {
            _searchService = new SearchService ();
        }
        public List<Artist> Search(string name, SearchEnum type)
        {
            var responseService = _searchService.Search(name, type.ToString());

            //...

            return new List<Artist>();
        }
    }
}
