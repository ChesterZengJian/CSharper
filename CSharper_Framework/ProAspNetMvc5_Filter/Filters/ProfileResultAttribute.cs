using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProAspNetMvc5_Filter.Filters
{
  public class ProfileResultAttribute : FilterAttribute, IResultFilter
  {
    private Stopwatch timer;
    public void OnResultExecuted(ResultExecutedContext filterContext)
    {
      timer.Stop();
      if (filterContext.Exception == null)
      {
        filterContext.HttpContext.Response.Write($"Timer: {timer.Elapsed.TotalSeconds:F6}");
      }
    }

    public void OnResultExecuting(ResultExecutingContext filterContext)
    {
      timer = Stopwatch.StartNew();
    }
  }
}