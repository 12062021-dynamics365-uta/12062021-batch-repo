using DataBaseAccess1;
using GamePlayLogic1;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rps_GameApi
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
            //this is where you will add 
            //// DI (Dependency Injection)
            ///there are 3 types of lifetimes for objects: 
            ///scoped = there is an instance of the object created for every call cycle in which the object is needed.
            ///singleton = there is one instance of the object created that lasts the lifetime of the compiliation
            ///transient = there is one object created and destroyed every time it's needed.
            services.AddScoped<IDatabaseAccess, DatabaseAccess>();
            services.AddScoped<IGamePlayLogic, GamePlayLogic>();
            services.AddScoped<IMapper, Mapper>();

            //// CORS

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Rps_GameApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rps_GameApi v1"));
            }

            app.UseHttpsRedirection();
            //app.UseCores()
            app.UseRouting();

            app.UseAuthorization();

            // here we are using a Lambda Expression...
            // AKA arrow function (JS),
            // Predicate( a method sent into another method.)
            app.UseEndpoints(endpoints => endpoints.MapControllers());

            //UseEndPoint()^^
            //// it has access to an array that contains all the controllers
            //// it will call this method on every endpoint in that array
            //// THAT will create an array of all mapped endpoints available at that compilation.
        }
    }
}
