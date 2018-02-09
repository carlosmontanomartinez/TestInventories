﻿using Inventories.Data.EntityFramework.Context;
using Inventories.Data.Interfaces;
using Inventories.Data.Models;
using Inventories.Data.Models.Errors;
using Inventories.Infrastructure.Interfaces;
using Inventories.Infrastructure.Services;
using Inventories.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Inventories
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
            services.AddMvc();
            services.AddSingleton<IApiConfigurable>(new Configuration()
            {
                ApplicationName = Configuration.GetSection("Errors:ApplicationName").Value,
                Version = Configuration.GetSection("Errors:Version").Value
            });

            var connectionString = Configuration.GetConnectionString("FoodsMxDbConnection");

            services.AddEntityFrameworkSqlServer().AddDbContext<FoodsMxDbContext>((serviceProvider, options) => options.UseSqlServer(connectionString).UseInternalServiceProvider(serviceProvider));

            var dbContextOptionsbuilder = new DbContextOptionsBuilder<FoodsMxDbContext>().UseSqlServer(connectionString);

            services.AddSingleton(dbContextOptionsbuilder.Options);

            services.AddScoped<IConsessionCinemaService, ConsessionCinemaService>();
            services.AddScoped<IStatusService, StatusService>();
            services.AddScoped<ICinemaService, CinemaService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMiddleware<ExceptionMiddleware>();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseApiKey(
                Configuration
            );
            app.UseMvc();
        }
        
    }
}
