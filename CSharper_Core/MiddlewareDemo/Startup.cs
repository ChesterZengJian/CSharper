using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MiddlewareDemo
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});

            #region Custom Middleware

            app.Use(next =>
            {
                return async context =>
                {
                    Console.WriteLine("Hello World 01");
                    await context.Response.WriteAsync("<h1>Hello World 01, Start <h1 />");
                    await next.Invoke(context);
                    await context.Response.WriteAsync("Hello World 01, End <br />");
                };
            });

            app.Use(next =>
            {
                return async context =>
                {
                    Console.WriteLine("Hello World 02");
                    await context.Response.WriteAsync("Hello World 02, Start <br />");
                    await next.Invoke(context);
                    await context.Response.WriteAsync("Hello World 02, End <br />");
                };
            });

            app.Use(next =>
            {
                return async context =>
                {
                    Console.WriteLine("Hello World 03");
                    await context.Response.WriteAsync("Hello World 03, Start <br />");
                    //await next.Invoke(context);
                    await context.Response.WriteAsync("Hello World 03, End <br />");
                };
            });

            #endregion
        }
    }
}
