﻿using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ServiceHub.Batch.Context.Utilities;
using MongoDB.Driver;

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
            services.AddSingleton<IUtility, BatchRepository>(serviceProvider =>
            {
                return new BatchRepository(
                    new MongoClient(connectionString)
                    .GetDatabase("batchdb")
                    .GetCollection<Context.Models.Batch>("batches"));
            });
            services.AddSingleton<BatchRepository>(serviceProvider =>
            {
                return new BatchRepository(
                    new MongoClient(connectionString)
                    .GetDatabase("batchdb")
                    .GetCollection<Context.Models.Batch>("batches"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddApplicationInsights(app.ApplicationServices);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
        }
    }
}
