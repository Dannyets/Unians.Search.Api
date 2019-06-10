using Search.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Search.Api.Interfaces
{
    public interface IElasticSearchService<T> where T : BaseDocument
    {
        Task<List<T>> Search(string keyword);

        Task<List<T>> SearchFields(string keyword, params Expression<Func<T, object>>[] fileds);

        Task<List<T>> GetAll();
    }
}
