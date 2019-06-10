using Microsoft.Extensions.Logging;
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
