using ProAspNetMvc5_ControllerAndAction.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace ProAspNetMvc5_ControllerAndAction.ControllerFatories
{
  public class CustomControllerFactory : IControllerFactory
  {
    public IController CreateController(RequestContext requestContext, string controllerName)
    {
      Type targetType = null;
      switch (controllerName.ToLower())
      {
        case "product":
          targetType = typeof(ProductController);
          break;
        case "customer":
          targetType = typeof(CustomerController);
          break;
        default:
          requestContext.RouteData.Values["controller"] = "Product";
          targetType = typeof(ProductController);
          break;
      }

      return targetType == null ? null : (IController)DependencyResolver.Current.GetService(targetType);
    }

    public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
    {
      return SessionStateBehavior.Default;    
      //return SessionStateBehavior.Required; // Full read-write session
      //return SessionStateBehavior.ReadOnly; // Read only session
      //return SessionStateBehavior.Disabled; // Non-Session
    }

    public void ReleaseController(IController controller)
    {
      IDisposable disposable = controller as IDisposable;
      if (disposable != null)
      {
        disposable.Dispose();
      }
    }
  }
}