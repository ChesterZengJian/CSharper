using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersDemo.Filters
{
    public class CustomResourceFilterAsyncAttribute : Attribute, IAsyncResourceFilter
    {
        public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
        {
            Console.WriteLine($"Enter {nameof(OnResourceExecutionAsync)}");

            context.Result = new ContentResult
            {
                Content = "Async resource unavailable - header not set."
            };

            //await next();

            //Console.WriteLine($"Leave {nameof(OnResourceExecutionAsync)}");
        }
    }
}
