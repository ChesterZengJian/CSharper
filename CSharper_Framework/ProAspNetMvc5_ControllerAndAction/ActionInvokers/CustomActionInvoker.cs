using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProAspNetMvc5_ControllerAndAction.ActionInvokers
{
  public class CustomActionInvoker : IActionInvoker
  {
    public bool InvokeAction(ControllerContext controllerContext, string actionName)
    {
      if (actionName == "Index")
      {
        controllerContext.HttpContext.Response.Write("This is output from the Index");
        return true; // called this action
      }
      return false; // 404 error
    }
  }
}