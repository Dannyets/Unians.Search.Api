using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Search.Api.Extensions;
using Search.Api.Interfaces;
using Search.Api.Models;

namespace Search.Api.Controllers
{
    public class ExerciseSearchController : BaseSearchController<ExerciseDocument>
    {
        public ExerciseSearchController(IElasticSearchService<ExerciseDocument> searchService, 
                                        ILogger<BaseSearchController<ExerciseDocument>> logger) : base(searchService, logger)
        {
        }
    }
}
