using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using app11.BAL;
using app11.Common;
using app11.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Prometheus;

namespace app11
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
            
            services.AddControllers();
            var server = Configuration["DBServer"] ?? "sqlserver";
            //var server = Configuration["DBServer"] ?? "localhost";
            //var server = Configuration["DBServer"] ?? "ms-sql-server";
            //var port = Configuration["DBPort"] ?? "1433";
            var port = Configuration["DBPort"]?? "1433";
            var user = Configuration["DBUser"] ?? "sa";
            var password = Configuration["DBPassword"] ?? "Qwerty@12345";
            var database = Configuration["Database"] ?? "webapidemodb";
            services.AddDbContext<CollegeDbContext>(options => 
            options.UseSqlServer($"Data Source={server,1433};Initial Catalog={database};Persist Security Info=True;User ID={user};Password={password}")
            );

            services.AddScoped<ProfessorsBal>();
            services.AddScoped<ProfessorsDal>();
             services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "app11 - WebApi"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Custom Metrics to count requests for each endpoint and the method
            var counter = Metrics.CreateCounter("api_path_counter", "Counts requests to the People API endpoints", new CounterConfiguration
            {
                LabelNames = new[] { "method", "endpoint" }
            });
            app.Use((context, next) =>
            {
                counter.WithLabels(context.Request.Method, context.Request.Path).Inc();
                return next();
            });
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "app11.WebApi.xml");
            });

            app.UseRouting();
            app.UseHttpMetrics();
            app.UseMetricServer();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            
        }
    }
}
