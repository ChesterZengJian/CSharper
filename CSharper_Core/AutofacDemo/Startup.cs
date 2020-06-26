using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using AutofacDemo.Interceptors;
using AutofacDemo.Models;
using AutofacDemo.Services;
using AutofacDemo.Services.Impl;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AutofacDemo
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        // ConfigureContainer is where you can register things directly
        // with Autofac. This runs after ConfigureServices so the things
        // here will override registrations made in ConfigureServices.
        // Don't build the container; that gets done for you by the factory.
        public void ConfigureContainer(ContainerBuilder builder)
        {
            // Register your own things directly with Autofac, like:

            #region AccountServiceImpl

            //builder.RegisterType<AccountServiceImpl>();
            //builder.RegisterType<AccountServiceImpl>().As<IAccountService>()
            //    .OnlyIf(reg => reg.IsRegistered(new TypedService(typeof(IAccountService))));
            //builder.RegisterType<DiffAccountServiceImpl>().As<IAccountService>().IfNotRegistered(typeof(IAccountService));

            #endregion

            #region Account Property

            //builder.RegisterType<User>();
            //var user = new User { Name = "user 1" };
            //builder.RegisterType<AccountWithPropertyService>()
            //    .As<IAccountService>()
            //    .WithProperty("User", user);

            #endregion

            #region Register AccountWithParamServiceImpl

            //builder.RegisterType<AccountWithParamServiceImpl>();

            #endregion

            #region AccountWithParamServiceImpl Register Parameter

            //builder.RegisterType<AccountWithParamServiceImpl>().UsingConstructor(typeof(string))
            //    .WithParameter(new TypedParameter(typeof(string),"Chester"));
            //builder.RegisterType<AccountWithParamServiceImpl>().UsingConstructor(typeof(string))
            //    .WithParameter("name", "Chester");
            //builder.RegisterType<AccountWithParamServiceImpl>().UsingConstructor(typeof(string))
            //    .WithParameter(new ResolvedParameter((pi, ctx) => pi.ParameterType == typeof(string) && pi.Name == "name",
            //    (pi, ctx) => "Chester Resolved"));
            //builder.Register((c, p) => new AccountWithParamServiceImpl(p.Named<string>("name")));

            #endregion

            #region Assemble Register

            //builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
            //    .Except<DiffAccountServiceImpl>()
            //    .PublicOnly()
            //    .Where(t => t.Name.EndsWith("Impl"))
            //    .AsImplementedInterfaces();

            #endregion

            #region Delegate Factory

            //builder.RegisterType<Shareholdings>();

            #endregion

            #region AOP

            builder.RegisterType<UserInterceptorServiceImpl>()
                .As<IUserInterceptorService<User>>()
                .EnableInterfaceInterceptors();
            builder.RegisterType<UserInterceptor>();

            #endregion
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
        }
    }
}
