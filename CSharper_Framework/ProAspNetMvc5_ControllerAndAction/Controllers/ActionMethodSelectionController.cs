using ProAspNetMvc5_ControllerAndAction.ActionMethodSelections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProAspNetMvc5_ControllerAndAction.Controllers
{
  public class ActionMethodSelectionController : Controller
  {
    // GET: ActionMethodSelection
    [NonAction]
    public ActionResult Index()
    {
      return Content("Controller: ActionMethodSelection<br/>Action:Index");
    }
    [ActionName("Index")]
    public ActionResult List()
    {
      return Content("Controller: ActionMethodSelection<br/>Action:List");
    }
    [Local]
    [ActionName("Index")]
    public ActionResult LocalIndex()
    {
      return Content("Controller: ActionMethodSelection<br/>Action:LocalIndex");
    }
  }
}