using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SwaggerControllers;

namespace SwaggerConfiguration
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Use Controllers
            var controllers = new Assembly[]
            {
                typeof(HomeController).Assembly
                , typeof(AccountController).Assembly
            };
            foreach (var controller in controllers)
            {
                services.AddControllers().AddApplicationPart(controller);
            }

            // User swagger service
            services.AddSwaggerGen(swagger =>
            {
                var infoConfig = _configuration.GetSection("Swagger:Doc:info");

                foreach (var controller in controllers)
                {
                    swagger.IncludeXmlComments(Path.ChangeExtension(controller.Location, "xml"), true);
                }

                var info = infoConfig.Get<OpenApiInfo>();

                swagger.SwaggerDoc(info.Version, info);
                //swagger.SwaggerDoc("v1", new OpenApiInfo() { Title = "My API" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Use swagger middleware
           var swaggerCfg = _configuration.GetSection("Swagger");
            var uiCfg = swaggerCfg.GetSection("Ui");
            var epCfg = uiCfg.GetSection("EndPoint");
            var routeTemplate = swaggerCfg.GetSection("RouteTemplate").Value.TrimStart('/');

            app.UseSwagger(options => { options.RouteTemplate = routeTemplate; });
            //app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(url: $"/{routeTemplate.Replace("{documentName}", epCfg["RelatedDocVersion"])}", epCfg["Name"]);
                //c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API");
            });

            app.UseRouting();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
