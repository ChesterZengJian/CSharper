using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProAspNetMvc5_RouteSystem.App_Start
{
  public class LegacyRoute : RouteBase
  {
    private string[] urls;
    public LegacyRoute(params string[] targetUrls)
    {
      urls = targetUrls;
    }

    public override RouteData GetRouteData(HttpContextBase httpContext)
    {
      RouteData routeData = null;
      string requestUrl = httpContext.Request.AppRelativeCurrentExecutionFilePath;
      // If request the target URL, it will go to the Legacy/Index
      if (urls.Contains(requestUrl, StringComparer.OrdinalIgnoreCase))
      {
        routeData = new RouteData(this, new MvcRouteHandler());
        routeData.Values.Add("controller", "Legacy");
        routeData.Values.Add("action", "Index");
        routeData.Values.Add("legacyURL", requestUrl);
      }
      return routeData;
    }

    public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
    {
      VirtualPathData result = null;

      if (values.ContainsKey("legacyURL") && urls.Contains((string)values["legacyURL"], StringComparer.OrdinalIgnoreCase))
      {
        result = new VirtualPathData(this, new UrlHelper(requestContext).Content((string)values["legacyURL"]).Substring(1));
      }
      return result;
    }
  }
}