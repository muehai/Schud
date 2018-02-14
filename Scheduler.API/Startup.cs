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

namespace Scheduler.API
{
    
    public class Startup
    {
        //private static string _applicationPath = string.Empty;
        //string sqlConnectionString = string.Empty;
        //bool useInMemoryProvider = false;
        //public IConfigurationRoot Configuration { get; }


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
