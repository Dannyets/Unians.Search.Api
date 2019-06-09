using Microsoft.AspNetCore.Mvc;
using Search.Api.Interfaces;
using Search.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BaseSearchController<T> : ControllerBase where T : BaseDocument
    {
        private ISearchService<T> _searchService;

        public BaseSearchController(ISearchService<T> searchService)
        {
            _searchService = searchService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<T>>> Search(string keyword)
        {
            return await _searchService.Search(keyword);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<T>>> Get()
        {
            return await _searchService.GetAll();
        }
    }
}
