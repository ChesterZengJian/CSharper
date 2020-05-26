using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProAspNetMvc5_Filter.Filters
{
  public class ProfileActionAttribute : FilterAttribute, IActionFilter
  {
    private Stopwatch timer;
    public void OnActionExecuted(ActionExecutedContext filterContext)
    {
      timer.Stop();
      if (filterContext.Exception==null)
      {
        filterContext.HttpContext.Response.Write($"Timer: {timer.Elapsed.TotalSeconds:F6}");
      }
    }

    public void OnActionExecuting(ActionExecutingContext filterContext)
    {
      timer = Stopwatch.StartNew();
    }
  }
}