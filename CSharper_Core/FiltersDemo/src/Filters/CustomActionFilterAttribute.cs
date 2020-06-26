using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace FiltersDemo.Filters
{
    public class CustomActionFilterAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"Enter {nameof(OnActionExecuted)}");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"Enter {nameof(OnActionExecuting)}");
        }
    }
}