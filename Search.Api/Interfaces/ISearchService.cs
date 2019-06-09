using Search.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search.Api.Interfaces
{
    public interface ISearchService<T> where T : BaseDocument
    {
        Task<List<T>> Search(string keyword);

        Task<List<T>> GetAll();
    }
}
