using Autofac;
using Autofac.Core;
using AutofacDemo.Models;
using AutofacDemo.Services;
using AutofacDemo.Services.Impl;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AutofacDemo.Controllers
{
    [Route("index.html")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        #region IAccountService

        //private readonly IAccountService m_accountServiceImpl;
        //public AccountsController(IAccountService accountServiceImpl)
        //{
        //    m_accountServiceImpl = accountServiceImpl;
        //}

        //public string Get()
        //{
        //    m_accountServiceImpl.Print();
        //    return "All accounts";
        //}

        #endregion

        #region AccountServiceImpl

        //private readonly AccountServiceImpl m_accountServiceImpl;
        //public AccountsController(AccountServiceImpl accountServiceImpl)
        //{
        //    m_accountServiceImpl = accountServiceImpl;
        //}

        //public string Get()
        //{
        //    return "All accounts";
        //}

        #endregion

        #region AccountWithParamServiceImpl Register Parameter

        //private readonly AccountWithParamServiceImpl m_accountServiceImpl;

        //public AccountsController(AccountWithParamServiceImpl accountServiceImpl)
        //{
        //    m_accountServiceImpl = accountServiceImpl;
        //}

        //public string Get()
        //{
        //    return "All accounts";
        //}

        #endregion

        #region Resolved Parameter

        //private readonly ILifetimeScope m_container;
        //public AccountsController(ILifetimeScope container)
        //{
        //    m_container = container;

        //}
        //public string Get()
        //{
        //    using var scope = m_container.BeginLifetimeScope();
        //    var serviceImpl = scope.Resolve<AccountWithParamServiceImpl>(new NamedParameter("name", "Chester Named"));
        //    var serviceImpl = scope.Resolve<AccountWithParamServiceImpl>(
        //        new TypedParameter(typeof(string), "Chester Type")
        //        );
        //    var serviceImpl = scope.Resolve<AccountWithParamServiceImpl>(
        //        new ResolvedParameter((pi, ctx) => pi.ParameterType == typeof(string) && pi.Name == "name",
        //            (pi, ctx) => "Chester Resolve"));

        //    return "All account";
        //}

        #endregion

        #region Delegate Factory

        //private readonly Shareholdings.Factory m_factory;
        //public AccountsController(Shareholdings.Factory factory)
        //{
        //    m_factory = factory;
        //}

        //public string Get()
        //{
        //    return m_factory("sh", 12).Symbol;
        //}

        #endregion

        #region AOP

    private IUserInterceptorService<User> m_userInterceptorService;

    public AccountsController(IUserInterceptorService<User> userInterceptorService)
    {
        m_userInterceptorService = userInterceptorService;
    }

    public async Task<string> Get()
    {
        var user = await m_userInterceptorService.AddUser(new User { Name = "Test AOP" });
        return user.Name;
    }

        #endregion
    }
}