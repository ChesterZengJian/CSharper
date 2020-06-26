using Autofac.Extras.DynamicProxy;
using AutofacDemo.Interceptors;
using AutofacDemo.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Threading.Tasks;

namespace AutofacDemo.Services
{
[Intercept(typeof(UserInterceptor))]
public interface IUserInterceptorService<T>
    where T : class
{
    Task<T> AddUser(T user);
}
}