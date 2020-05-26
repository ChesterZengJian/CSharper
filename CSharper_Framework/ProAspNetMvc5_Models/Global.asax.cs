using ProAspNetMvc5_Models.ModelBinders;
using ProAspNetMvc5_Models.Models;
using ProAspNetMvc5_Models.ValueProviderFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProAspNetMvc5_Models
{
  public class MvcApplication : System.Web.HttpApplication
  {
    protected void Application_Start()
    {
      AreaRegistration.RegisterAllAreas();
      RouteConfig.RegisterRoutes(RouteTable.Routes);
      System.Web.Mvc.ValueProviderFactories.Factories.Insert(0, new CustomValueProviderFactory());
      //System.Web.Mvc.ModelBinders.Binders.Add(typeof(Address), new AddressBinder());
    }
  }
}
