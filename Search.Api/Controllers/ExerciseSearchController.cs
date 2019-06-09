using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Search.Api.Interfaces;
using Search.Api.Models;

namespace Search.Api.Controllers
{
    public class ExerciseSearchController : BaseSearchController<ExerciseDocument>
    {
        public ExerciseSearchController(ISearchService<ExerciseDocument> searchService) : base(searchService)
        {
        }
    }
}
