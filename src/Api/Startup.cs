using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Extensions;
using Api.Middlewares;
using Application.Services.Interfaces;
using Application.Settings;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Infrastructure.EntityFrameworkCore;
using Infrastructure.Extensions;
using Infrastructure.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public ILifetimeScope AutofacContainer { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DatabaseContext>();
            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddAuthorizationWithConfiguration();
            services.AddJwt(Configuration.GetSettings<JwtSettings>().SecretKey);
        }

        public void ConfigureContainer(ContainerBuilder builder)
            => builder.RegisterModule(new ContainerModule(Configuration));

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            this.AutofacContainer = app.ApplicationServices.GetAutofacRoot();
            var dataInitializerSettings = AutofacContainer.Resolve<DataInitializerSettings>();
            
            if(dataInitializerSettings.SeedData) AutofacContainer.Resolve<IDataInitializer>().SeedAsync();


            
            if (!env.IsDevelopment()) app.UseMiddleware<ExceptionHandlerMiddleware>();


            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
