using System;
using System.Threading.Tasks;
using AutofacDemo.Models;
using Castle.Core.Logging;
using Castle.DynamicProxy;

namespace AutofacDemo.Interceptors
{
public class UserInterceptor : IInterceptor
{
    public void Intercept(IInvocation invocation)
    {
        Console.WriteLine($"Before Execution {invocation.ReturnValue}");
        invocation.Proceed();

        if (invocation.ReturnValue is Task<User> taskResult)
        {
            taskResult.ContinueWith(t => { Console.WriteLine($"After Execution {t.Result.ToString()}"); },
                TaskContinuationOptions.None);
        }
        else
        {
            var result = (User)invocation.ReturnValue;
            Console.WriteLine($"After Execution {result.ToString()}");
        }
    }
}
}