using ProAspNetMvc5_ControllerAndAction.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProAspNetMvc5_ControllerAndAction.Controllers
{
  public class DerivedController : Controller
  {
    public ActionResult Index()
    {
      return new CustomRedirectResult() { Url = "/Basic/Index" };
    }
  }
}