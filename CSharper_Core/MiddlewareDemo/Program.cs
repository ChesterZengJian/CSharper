using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MiddlewareDemo.CustomMiddleware;

namespace MiddlewareDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region WebHostBuilder

            var hostBuilder = CreateHostBuilder(args);
            var host = hostBuilder.Build();
            host.Run();

            #endregion

            #region CustomMiddlewareBuilder

            //var customApplicationBuilder = new CustomApplicationBuilder();

            //customApplicationBuilder.Use(next =>
            //{
            //    return context =>
            //    {
            //        Console.WriteLine("Hello World 01");
            //        Console.WriteLine("<h1>Hello World 01, Start <h1 />");
            //        next.Invoke(context);
            //        Console.WriteLine("Hello World 01, End <br />");
            //    };
            //});

            //customApplicationBuilder.Use(next =>
            //{
            //    return context =>
            //    {
            //        Console.WriteLine("Hello World 02");
            //        Console.WriteLine("<h1>Hello World 02, Start <h1 />");
            //        next.Invoke(context);
            //        Console.WriteLine("Hello World 02, End <br />");
            //    };
            //});

            //customApplicationBuilder.Use(next =>
            //{
            //    return context =>
            //    {
            //        Console.WriteLine("Hello World 03");
            //        Console.WriteLine("<h1>Hello World 03, Start <h1 />");
            //        next.Invoke(context);
            //        Console.WriteLine("Hello World 03, End <br />");
            //    };
            //});

            //var customRequestDelegate = customApplicationBuilder.Build();
            //customRequestDelegate.Invoke(new CustomHttpContext());

            #endregion
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                     .ConfigureWebHostDefaults(webBuilder =>
                     {

                         #region DefaultConfigure

                         //webBuilder.UseStartup<Startup>();

                         #endregion

                         #region CustomConfigure

                         webBuilder.UseKestrel(options => { options.Listen(IPAddress.Loopback, 10086); })
                             .Configure(app =>
                             {
                                 app.Run(context =>
                                 {
                                     return Task.Run(() => { Console.WriteLine("Configure web"); });
                                 });
                             });

                         #endregion
                     });
        }
    }
}