using ProAspNetMvc5_ControllerAndAction.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProAspNetMvc5_ControllerAndAction.ControllerActivators
{
  public class CustomControllerActivator : IControllerActivator
  {
    public IController Create(RequestContext requestContext, Type controllerType)
    {
      if (controllerType == typeof(ProductController))
      {
        controllerType = typeof(CustomerController);
      }
      return (IController)DependencyResolver.Current.GetService(controllerType);
    }
  }
}