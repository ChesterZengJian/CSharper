using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiltersDemo.Filters
{
    public class CustomExceptionFilterAttribute : Attribute, IExceptionFilter
    {
        #region Log Exception

        //private readonly ILogger m_logger;
        //public CustomExceptionFilterAttribute(ILogger<CustomExceptionFilterAttribute> logger)
        //{
        //    m_logger = logger;
        //}
        ///// <summary>
        ///// Called when exception occur
        ///// </summary>
        ///// <param name="context"></param>
        //public override void OnException(ExceptionContext context)
        //{
        //    if (!context.ExceptionHandled)
        //    {
        //        m_logger.LogError("This is a error log");
        //        Console.WriteLine($"{context.HttpContext.Request.Path} {context.Exception.Message}");
        //        context.Result = new JsonResult(new
        //        {
        //            Result = true,
        //            Msg = "Unexpected exception"
        //        });
        //        context.ExceptionHandled = true;
        //    }
        //}

        #endregion

        public void OnException(ExceptionContext context)
        {
            Console.WriteLine($"Enter {nameof(OnException)}");
            if (!context.ExceptionHandled)
            {
                Console.WriteLine($"{context.HttpContext.Request.Path} {context.Exception.Message}");
                context.Result = new JsonResult(new
                {
                    Result = true,
                    Msg = "Unexpected exception"
                });
                context.ExceptionHandled = true;
            }
        }
    }
}
