using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Spotify.Domain.Enums;
using Spotify.Domain.Interfaces;

namespace Spotify.Api.Controllers
{
    [Route("api/search")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchBusiness _searchBusiness;
        private readonly Random _random;
        private readonly int[] data = new int[] { 4, 2, 6, 5, 1, 2 };
        public SearchController(ISearchBusiness business)
        {
            _searchBusiness = business;
            _random = new Random();
        }

        [HttpGet]
        public IActionResult Get(string name, SearchEnum type)
        {

            var response = _searchBusiness.Search(name, type);
           
            return Ok(response);
        }







        public async Task<IEnumerable<int>> GetRandomAsync(int limit)
        {
            await Task.Delay(2000);
            var result = Enumerable.Range(1, limit).Select(i => i + _random.Next(1, limit));

            return result;
        }


        [HttpGet("/en-paralelo")]
        public Task<List<int>> GetDemo()
        {
            var sw = new Stopwatch();
            sw.Start();

            var response = new List<int>();

            IEnumerable<Task<IEnumerable<int>>> dataTasks = data.Select(GetRandomAsync);

            var continuation = Task.WhenAll(dataTasks);
            continuation.Wait();

            foreach (var itemTask in continuation.Result)
                response.AddRange(itemTask);

            string time = $"Running for {sw.Elapsed.TotalSeconds} seconds";
            Console.WriteLine(time);

            return Task.FromResult(response);
        }

        [HttpGet("/en-cola")]
        public async Task<IActionResult> GetDemo2()
        {
            var sw = new Stopwatch();
            sw.Start();

            var response = new List<int>();

            foreach (var idArtista in data)
            {
                var topTrack = await GetRandomAsync(idArtista);
                response.AddRange(topTrack);
            }

            string time = $"Running for {sw.Elapsed.TotalSeconds} seconds";
            return base.Ok(new
            {
                elements = response,
                time
            });
        }

    }
}
