using Nest;
using Search.Api.Interfaces;
using Search.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search.Api.Clients
{
    public class GenericElasticClient<T> : ElasticClient, IGenericElasticClient<T> where T : BaseDocument
    {
        public GenericElasticClient(ConnectionSettings connectionSettings) : base(connectionSettings)
        {
            
        }
    }
}
