using Search.Api.Interfaces;
using Search.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Search.Api.Services
{
    public class ExerciseSearchService : BaseElasticSearchService<ExerciseDocument>
    {
        public ExerciseSearchService(IGenericElasticClient<ExerciseDocument> elasticClient) : base(elasticClient)
        {
        }

        public override async Task<List<ExerciseDocument>> Search(string keyword)
        {
            var searchKeyword = $"*{keyword.ToLower()}*";

            var searchResult = await SearchFields(keyword, f => f.Title, f => f.Description);

            return searchResult;
        }
    }
}
