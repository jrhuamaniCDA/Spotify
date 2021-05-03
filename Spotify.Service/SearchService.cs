using System;
using System.Net.Http;
using Spotify.Domain.Interfaces;
using Spotify.Domain.Models;

namespace Spotify.Service
{
    public class SearchService : ISearchService
    {
        private readonly HttpClient _httpClient;
        private const string API_KEY = "SSSSSSSSSSSSSS";
        public SearchService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://api.spotify.com/v1/search");
        }

        public ArtistSearch Search(string name, string type)
        {
            //https://api.spotify.com/v1/search?query=oasis&type=artist
            // [HEADERS]
            // Authetitcaton - Bearer [base64]

            // Deserializar ArtistSearch

            return new ArtistSearch();
        }
    }
}
