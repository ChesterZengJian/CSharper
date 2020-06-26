using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace FiltersDemo.Filters
{
    public class CustomResultFilterAttribute : Attribute, IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
            Console.WriteLine($"Enter {nameof(OnResultExecuted)}");
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            Console.WriteLine($"Enter {nameof(OnResultExecuting)}");
        }
    }
}