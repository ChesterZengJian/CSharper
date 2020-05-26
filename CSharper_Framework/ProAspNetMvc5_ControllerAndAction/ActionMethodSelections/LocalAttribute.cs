using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace ProAspNetMvc5_ControllerAndAction.ActionMethodSelections
{
  public class LocalAttribute : ActionMethodSelectorAttribute
  {
    public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
    {
      return controllerContext.HttpContext.Request.IsLocal;
    }
  }
}