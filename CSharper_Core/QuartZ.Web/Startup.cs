using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrystalQuartz.AspNetCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Quartz.Impl;
using QuartZ.Web.HostServices;
using QuartZ.Web.Services;

namespace QuartZ.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddScoped<SendMessageService>();
            services.AddScoped<SendMessageJob>();
            services.AddSingleton<QuartzManager>();
            services.AddHostedService<SchedulerHostService>();
            services.TryAddSingleton(typeof(SchedulerHostService));
            services.AddSingleton<SchedulerHostService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            var factory = new StdSchedulerFactory();
            var scheduler = factory.GetScheduler().Result;
            app.UseCrystalQuartz(() => scheduler);
        }
    }
}
