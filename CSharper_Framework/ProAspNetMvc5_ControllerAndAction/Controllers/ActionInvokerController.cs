using ProAspNetMvc5_ControllerAndAction.ActionInvokers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProAspNetMvc5_ControllerAndAction.Controllers
{
  public class ActionInvokerController : Controller
  {
    public ActionInvokerController()
    {
      this.ActionInvoker = new CustomActionInvoker();
    }
  }
}