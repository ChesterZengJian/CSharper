using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProAspNetMvc5_RouteSystem.AdditionalControllers
{
  public class HomeController : Controller
  {
    // GET: Home
    public ActionResult Index()
    {
      return Content(@"Namespace: ProAspNetMvc5_RouteSystem.AdditionalControllers <br/>
                       Controller: Home <br/>
                       Action: Index");
    }
  }
}