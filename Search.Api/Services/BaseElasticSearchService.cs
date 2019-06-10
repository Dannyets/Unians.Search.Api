using Nest;
using Search.Api.Interfaces;
using Search.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Search.Api.Services
{
    public abstract class BaseElasticSearchService<T> : IElasticSearchService<T> where T : BaseDocument
    {
        private IGenericElasticClient<ExerciseDocument> _elasticClient;

        public BaseElasticSearchService(IGenericElasticClient<ExerciseDocument> elasticClient)
        {
            _elasticClient = elasticClient;
        }

        public async Task<List<T>> GetAll()
        {
            var searchResult = await _elasticClient.SearchAsync<T>(s => s.Query(q => q.MatchAll()));

            return GetResultsFromSearchResponse(searchResult);
        }

        public abstract Task<List<T>> Search(string keyword);

        public async Task<List<T>> SearchFields(string keyword, params Expression<Func<T, object>>[] fields)
        {
            var searchKeyword = $"*{keyword.ToLower()}*";

            var searchResult = await _elasticClient.SearchAsync<T>(s => s.
                Query(q => q
                    .QueryString(queryDescriptor => queryDescriptor
                        .Query(searchKeyword)
                        .Fields(fieldsDescriptor => fieldsDescriptor.Fields(fields))
                )));

            return GetResultsFromSearchResponse(searchResult);
        }

        private List<T> GetResultsFromSearchResponse(ISearchResponse<T> searchResponse)
        {
            return searchResponse.Hits.Select(hit => hit.Source).ToList();
        }
    }
}
