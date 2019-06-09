using Nest;
using Search.Api.Interfaces;
using Search.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search.Api.Services
{
    public class ExerciseSearchService : ISearchService<ExerciseDocument>
    {
        private IGenericElasticClient<ExerciseDocument> _elasticClient;

        public ExerciseSearchService(IGenericElasticClient<ExerciseDocument> elasticClient)
        {
            _elasticClient = elasticClient;
        }

        public async Task<List<ExerciseDocument>> Search(string keyword)
        {
            var searchKeyword = $"*{keyword.ToLower()}*";

            var searchResult = await _elasticClient.SearchAsync<ExerciseDocument>(s => s.
                Query(q => q
                    .QueryString(queryDescriptor => queryDescriptor
                        .Query(searchKeyword)
                        .Fields(fieldsDescriptor => fieldsDescriptor
                           .Fields(f => f.Title,
                                   f => f.Description)))
                ));

            return searchResult.Hits.Select(hit => hit.Source).ToList();
        }

        public async Task<List<ExerciseDocument>> GetAll()
        {
            var searchResult = await _elasticClient.SearchAsync<ExerciseDocument>(s => s.Query(q => q.MatchAll()));

            return searchResult.Hits.Select(hit => hit.Source).ToList();
        }
    }
}
