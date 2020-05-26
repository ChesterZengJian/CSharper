using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProAspNetMvc5_ControllerAndAction.Controllers
{
  public class ExampleController : Controller
  {
    // GET: Example
    public ViewResult ViewResult()
    {
      return View("MyView");
    }

    public ViewResult ViewSelection()
    {
      return View(DateTime.Now);
    }

    public ViewResult ViewBags()
    {
      ViewBag.Message = "Hello";
      return View();
    }

    public RedirectResult Redirect()
    {
      return RedirectPermanent("/Example/Index");
    }

    public RedirectToRouteResult RedirectRoute()
    {
      return RedirectToRoute(new
      {
        Controller = "Example",
        Action = "Index",
        id = "MyID"
      });
    }

    public HttpStatusCodeResult StatusCode()
    {
      return new HttpStatusCodeResult(404, "No Found");
    }
  }
}