using Nest;
using Search.Api.Models;

namespace Search.Api.Interfaces
{
    public interface IGenericElasticClient<T> : IElasticClient where T : BaseDocument
    {

    }
}
