using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Routing.Constraints;
using System.Web.Routing;

namespace ProAspNetMvc5_RouteSystem.App_Start
{
  public class MyRoutesConfig
  {
    public static void RegisterRoutes(RouteCollection routes)
    {
      // Enable attribute route
      routes.MapMvcAttributeRoutes();

      // Method 1 Define Route rules by Add()
      //Route myRoute = new Route("{controller}/{action}", new MvcRouteHandler());
      //routes.Add(myRoute);

      // Method 2 Define Route rules by Map
      //routes.MapRoute(
      //  name: null,
      //  url: "{controller}/{action}",
      //  defaults: new
      //  {
      //    Controller = "Home",
      //    Action = "Index",
      //    id = UrlParameter.Optional
      //  });

      // Define static URL fragment
      //routes.MapRoute(
      //  name: null,
      //  url: "Public/X{controller}/{action}",
      //  defaults: new
      //  {
      //    Controller = "Home",
      //    Action = "Index",
      //    id = UrlParameter.Optional
      //  });

      // Define static URL fragment
      //routes.MapRoute(
      //  name: null,
      //  url: "{controller}/{action}/{id}/{*catchalll}"
      //  );

      // Specifies namespace priority
      //routes.MapRoute(
      //  name: null,
      //  url: "{controller}/{action}",
      //  defaults: new
      //  {
      //    Controller = "Home",
      //    Action = "Index",
      //    id = UrlParameter.Optional
      //  },
      //  new[] {
      //    //"ProAspNetMvc5_RouteSystem.AdditionalControllers",
      //    "ProAspNetMvc5_RouteSystem.SameControllers"
      //  });

      //routes.MapRoute(
      //  name: null,
      //  url: "{controller}/{action}",
      //  defaults: new
      //  {
      //    Controller = "Home",
      //    Action = "Index",
      //    id = UrlParameter.Optional
      //  },
      //  new[] {
      //    "ProAspNetMvc5_RouteSystem.Controllers"
      //  });

      // Stop looking another namespace if you can't find
      //var myRoute = routes.MapRoute(
      //  name: null,
      //  url: "{controller}/{action}",
      //  defaults: new
      //  {
      //    Controller = "Home",
      //    Action = "Index",
      //    id = UrlParameter.Optional
      //  },
      //  new[] {
      //    "ProAspNetMvc5_RouteSystem.SameControllers"
      //  });
      //myRoute.DataTokens["UseNamespaceFallback"] = false; // If you can't find an action, use this stop if you don't want to continue looking in another namespace.

      // Constrained routing
      //routes.MapRoute(
      //  name: null,
      //  url: "{controller}/{action}",
      //  new {
      //    Controller="^H.*"
      //  },
      //  new[] {
      //    "ProAspNetMvc5_RouteSystem.Controllers"
      //  });

      // Constrain a set of values by `|`
      //routes.MapRoute(
      //  name: null,
      //  url: "{controller}/{action}",
      //  new
      //  {
      //    Controller = "^H.*",
      //    Action = "^Index$|^About$"
      //  },
      //  new[] {
      //    "ProAspNetMvc5_RouteSystem.Controllers"
      //  });

      // Type and property constraints
      //routes.MapRoute(
      //  name: null,
      //  url: "{controller}/{action}",
      //  new
      //  {
      //    Controller = "^H.*",
      //    Action = "^Index$|^About$",
      //    HttpMethodConstraint = new HttpMethodConstraint("GET"),   // The HttpMethod must be "GET"
      //    id = new CompoundRouteConstraint(new IRouteConstraint[]
      //    {
      //      new RangeRouteConstraint(10,20),
      //      new MinLengthRouteConstraint(1)
      //    })                                                       // The id must between 10 and 20 and the minimum length > 1      
      //  },
      //  new[] {
      //    "ProAspNetMvc5_RouteSystem.Controllers"
      //  });

      // Legacy Route
      //routes.Add(new LegacyRoute("~/articles/windows_old_page"
      //                            , "~/articles/windows_old_page.html"
      //                            , "~/articles/windows_old_page.txt"));

      // Custom RouteHandler
      routes.Add(new Route("SayHello", new CustomRouteHandler()));

      // Custom constraints
      //routes.MapRoute(
      //  name: null,
      //  url: "{controller}/{action}",
      //  new
      //  {
      //    Controller = "Home",
      //    Action = "Index"
      //  },
      //  new
      //  {
      //    customConstraint = new UserAgentConstraint("Chrome") // If the browser isn't Chrome, it can't work.
      //  },
      //  new[] {
      //    "ProAspNetMvc5_RouteSystem.Controllers"
      //  });



    }
  }
}