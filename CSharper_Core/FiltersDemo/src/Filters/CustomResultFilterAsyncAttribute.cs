using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;

namespace FiltersDemo.Filters
{
    public class CustomResultFilterAsyncAttribute : Attribute, IAsyncResultFilter
    {
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            Console.WriteLine($"Enter {nameof(OnResultExecutionAsync)}");
            await next();
            Console.WriteLine($"Leave {nameof(OnResultExecutionAsync)}");
        }
    }
}