using Nest;
using Search.Api.Interfaces;
using Search.Api.Models;

namespace Search.Api.Clients
{
    public class GenericElasticClient<T> : ElasticClient, IGenericElasticClient<T> where T : BaseDocument
    {
        public GenericElasticClient(ConnectionSettings connectionSettings) : base(connectionSettings)
        {
            
        }
    }
}
