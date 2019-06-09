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
            var searchResult = await _elasticClient.SearchAsync<ExerciseDocument>(search => search.
                Query(query => query.
                    Match(m => m
                        .Field(p => p.Title)
                        .Query(keyword))));

            return searchResult.Hits.Select(hit => hit.Source).ToList();
        }

        public async Task<List<ExerciseDocument>> GetAll()
        {
            var searchResult = await _elasticClient.SearchAsync<ExerciseDocument>(s => s.Query(q => q.MatchAll()));

            return searchResult.Hits.Select(hit => hit.Source).ToList();
        }
    }
}
