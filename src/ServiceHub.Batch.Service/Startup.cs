using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ServiceHub.Batch.Context.Utilities;
using MongoDB.Driver;
using Swashbuckle.AspNetCore.Swagger;

namespace ServiceHub.Batch.Service
{
    public class Startup
    {
        public IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            const string connectionString = @"mongodb://db";
            services.AddMvc();
            services.AddSingleton<IUtility, BatchRepository>();
            services.AddSingleton<BatchRepository>();
            services.AddSingleton(mc =>
                new MongoClient(connectionString)
                    .GetDatabase("batchdb")
                    .GetCollection<Context.Models.Batch>("batches")
            );

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Revature Housing ServiceHub Batch API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddApplicationInsights(app.ApplicationServices);
            ApplicationLogging.ConfigureLogger("service");
            ApplicationLogging.LoggerFactory = loggerFactory;

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Revature Housing ServiceHub Batch API");
            });
        }
    }
}
