using System;
using System.Threading.Tasks;
using AspectCore.DynamicProxy;
using Microsoft.Extensions.Logging;

namespace AspectCoreDemo.Attributes
{
    public class TimeConsumingStatisticAttribute : AbstractInterceptorAttribute
    {
        public override async Task Invoke(AspectContext context, AspectDelegate next)
        {
            Console.WriteLine($"Begin {context.ProxyMethod.Name}");
            await next(context);
            Console.WriteLine($"End {context.ProxyMethod.Name}");
        }
    }
}