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
        public SearchController(ISearchBusiness searchBusiness)
        {
            _searchBusiness = searchBusiness;
        }

        [HttpGet]
        public IActionResult Get(string name, SearchEnum type)
        {
            var response = _searchBusiness.Search(name, type);
            return Ok(response);
        }
    }
}
