using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using Spotify.Domain.Interfaces;
using Spotify.Domain.Models;

namespace Spotify.Service
{
    public class SearchService : ISearchService
    {
        private readonly HttpClient _httpClient;
        public SearchService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://api.spotify.com")
            };
        }

        public ArtistSearch Search(string name, string type)
        {
            try
            {
                string bearer = "BQD-rdvJnNZnveorwntOCp8FlqdigzBF1bYR9QiDH2z5KXH7f1eLrUZ9JcAv9cfpvysLQKwyFZaPH1FKWGdaJ4a2TgCqa57tP1scaCSRFPOZWGgKN_FO755PNEfiJZvYtNvgBdDASQPHaAQ";
                string uri = $"/v1/search?query={name}&type={type.ToLower()}";

                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {bearer}");

                var result = _httpClient.GetAsync(uri).Result;

                //result.EnsureSuccessStatusCode(); // si no es un 200...

                var status = (int)result.StatusCode;
                //var list = new List<ArtistSearch>();



                var responseJson = result.Content.ReadAsStringAsync().Result;

                // Deserializar ArtistSearch
                var response = JsonSerializer.Deserialize<ArtistSearch>(responseJson);

                return response;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("error inesperado:" + ex.Message);

                return null;
            }
        }
    }
}

//VerifyResponse();
//if (!result.IsSuccessStatusCode)
//{
//    switch (result.StatusCode)
//    {
//        case HttpStatusCode.BadRequest:
//            throw new Exception("BadRequest");
//            break;
//        default:
//            break;
//    } 
//}

//