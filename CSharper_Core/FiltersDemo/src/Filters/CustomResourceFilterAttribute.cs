using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FiltersDemo.Filters
{
    public class CustomResourceFilterAttribute : Attribute, IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Console.WriteLine($"Enter {nameof(OnResourceExecuted)}");
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine($"Enter {nameof(OnResourceExecuting)}");
            //context.Result = new ContentResult
            //{
            //    Content = "Resource unavailable - header not set. "
            //};
        }
    }
}
