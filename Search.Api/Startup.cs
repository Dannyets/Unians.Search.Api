using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Runtime;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Search.Api.Extensions;
using Search.Api.Interfaces;
using Search.Api.Models;
using Search.Api.Services;

namespace Search.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddExerciseElasticSearch(Configuration);

            services.AddTransient<ISearchService<ExerciseDocument>, ExerciseSearchService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            ConfigureLogger(loggerFactory);

            app.UseMvc();
        }

        private void ConfigureLogger(ILoggerFactory loggerFactory)
        {
            var loggerConfig = Configuration.GetAWSLoggingConfigSection();

            var accessKey = Environment.GetEnvironmentVariable("AWS_ACCESS_KEY");
            var secretKey = Environment.GetEnvironmentVariable("AWS_SECRET_KEY");

            var credentials = new BasicAWSCredentials(accessKey, secretKey);

            loggerConfig.Config.Credentials = credentials;

            loggerFactory.AddAWSProvider(loggerConfig, formatter: (logLevel, message, exception) => $"[{DateTime.UtcNow}] {logLevel}: {message}");
        }
    }
}
