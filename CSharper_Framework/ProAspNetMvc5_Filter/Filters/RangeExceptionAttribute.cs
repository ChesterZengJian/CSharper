using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProAspNetMvc5_Filter.Filters
{
  public class RangeExceptionAttribute : FilterAttribute, IExceptionFilter
  {
    public void OnException(ExceptionContext filterContext)
    {
      if (!filterContext.ExceptionHandled
        && filterContext.Exception is ArgumentOutOfRangeException)
      {
        var actualValue = ((ArgumentOutOfRangeException)filterContext.Exception).ActualValue;

        filterContext.Result = new ViewResult
        {
          ViewName = "RangeError"
          ,
          ViewData = new ViewDataDictionary<int>((int)actualValue)
        };
        filterContext.ExceptionHandled = true;
      }
    }
  }
}