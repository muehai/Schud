using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Scheduler.Data.Repositories;
using Scheduler.Data.Abstract;
using Scheduler.API.ViewModels.Mapping;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Diagnostics;
using Scheduler.API.Core;
using Scheduler.Data;

namespace Scheduler.API
{
    
    public class Startup
    {
        private static string _applicationPath = string.Empty;
        string sqlConnectionString = string.Empty;
        bool useInMemoryProvider = false;
        public IConfigurationRoot Configuration1 { get; }

        SchedulerDbInitializer SchedulerDb;


        //Add Start up functions
        public Startup(IHostingEnvironment env)
        {
            _applicationPath = env.WebRootPath;
            var builder = new ConfigurationBuilder()
                            .SetBasePath(env.ContentRootPath)
                            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                            .AddEnvironmentVariables();


            //if (env.IsDevelopment())
            //{
            //    // This reads the configuration keys from the secret store.
            //    // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
            //    builder.AddUserSecrets<Startup>();
            //}

            Configuration1 = builder.Build();
        }



        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string sqlConnectionString = Configuration1.GetConnectionString("DefaultConnection");

            try
            {
                useInMemoryProvider = bool.Parse(Configuration1["AppSettings: InMemoryProvider"]);
            }
            catch { }

            services.AddDbContext<SchedulerContext>(options => {
                switch (useInMemoryProvider)
                {
                    case true:
                        options.UseInMemoryDatabase();
                        break;
                    default:
                        options.UseSqlServer(sqlConnectionString,
                    b => b.MigrationsAssembly("Scheduler.API"));
                        break;
                }
            });

            //Repositories for Sculdes message 
            services.AddScoped<IScheduleRepository, ScheduleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAttendeeRepository, AttendeeRepository>();


            // Automapper Configuration
            AutoMapperConfiguration.Configure();

            // Enable Cors
            services.AddCors();


            services.AddMvc()
                .AddJsonOptions(opts =>
                {
                    // Force Camel Case to JSON
                    opts.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });
            //SchedulerDbInitializer.Initialize(services.AddDbContext<>);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            SchedulerDb = new SchedulerDbInitializer();
            SchedulerDb.Initialize(app.ApplicationServices);
            app.UseStaticFiles();
            // Add MVC to the request pipeline.
            app.UseCors(builder =>
                builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());

            app.UseExceptionHandler(
             builder =>
             {
                 builder.Run(
                   async context =>
                   {
                       context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                       context.Response.Headers.Add("Access-Control-Allow-Origin", "*");

                       var error = context.Features.Get<IExceptionHandlerFeature>();
                       if (error != null)
                       {
                           context.Response.AddApplicationError(error.Error.Message);
                           await context.Response.WriteAsync(error.Error.Message).ConfigureAwait(false);
                       }
                   });
             });


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
         
            //SchedulerDbInitializer.Initialize(app.ApplicationServices);
        }
    }
}

