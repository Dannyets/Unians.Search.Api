using Amazon.Runtime.Internal.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        protected IElasticSearchService<T> _searchService;
        protected ILogger<BaseSearchController<T>> _logger;

        public BaseSearchController(IElasticSearchService<T> searchService,
                                    ILogger<BaseSearchController<T>> logger)
        {
            _searchService = searchService;
            _logger = logger;
        }

        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<T>>> Search(string keyword)
        {
            _logger.LogInformation($"Trying to search keyword: {keyword}");

            return await _searchService.Search(keyword);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<T>>> Get()
        {
            return await _searchService.GetAll();
        }
    }
}
