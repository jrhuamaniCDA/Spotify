using System;
using System.Collections.Generic;
using Spotify.Domain.Enums;
using Spotify.Domain.Interfaces;
using Spotify.Domain.Response;
using Spotify.Service;

namespace Spotify.Application
{
    public class SearchBusiness : ISearchBusiness
    {
        private readonly SearchService _searchService;
        public SearchBusiness()
        {
            _searchService = new SearchService();
        }
        public List<Artist> Search(string name, SearchEnum type)
        {
            var responseService = _searchService.Search(name, type.ToString());
            // ...

            return new List<Artist>();
        }

        public void Data() => Console.WriteLine("hola mundo");

    }
}
