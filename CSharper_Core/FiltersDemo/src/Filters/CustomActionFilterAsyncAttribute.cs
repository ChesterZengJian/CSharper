using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;

namespace FiltersDemo.Filters
{
    public class CustomActionFilterAsyncAttribute : Attribute, IAsyncActionFilter
    {
public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
{
    Console.WriteLine($"Enter {nameof(OnActionExecutionAsync)}");
    await next();
    Console.WriteLine($"Leave {nameof(OnActionExecutionAsync)}");
}
    }
}