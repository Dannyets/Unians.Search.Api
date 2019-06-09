using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using Search.Api.Clients;
using Search.Api.Interfaces;
using Search.Api.Models;
using System;

namespace Search.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddExerciseElasticSearch(this IServiceCollection services, IConfiguration configuration)
        {
            var elasticSearchUrl = configuration["ES:Exercise:Url"];

            var elasticSearchUri = new Uri(elasticSearchUrl);

            var connectionSettings = new ConnectionSettings(elasticSearchUri)
                .DefaultIndex("exercises")
                .DefaultMappingFor<ExerciseDocument>(exercise => exercise.IdProperty(e => e.Id));

            var client = new GenericElasticClient<ExerciseDocument>(connectionSettings);

            services.AddSingleton<IGenericElasticClient<ExerciseDocument>>(client);
        }
    }
}
