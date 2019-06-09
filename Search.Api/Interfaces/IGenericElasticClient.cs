using Nest;
using Search.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Search.Api.Interfaces
{
    public interface IGenericElasticClient<T> : IElasticClient where T : BaseDocument
    {

    }
}
