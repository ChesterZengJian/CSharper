using ProAspNetMvc5_Filter.Filters;
using ProAspNetMvc5_Filter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProAspNetMvc5_Filter.Controllers
{
  public class HomeController : Controller
  {
    [CustomAuthentication]
    [CustomAuthorize("admin")]
    public ActionResult Index()
    {
      return Content($"Welcome {((User)Session["User"]).UserName}");
    }

    //[RangeException]
    [HandleError(ExceptionType = typeof(ArgumentOutOfRangeException), View = "RangeError")]
    public string RangeTest(int id)
    {
      if (id > 100)
        return $"The id value is: {id}";
      else
        throw new ArgumentOutOfRangeException("id", id, "");
    }

    //[ProfileAction]
    //[ProfileResult(Order =1)]
    public string ActionFilterTest()
    {
      return "This is ActionFilterTest";
    }
  }
}