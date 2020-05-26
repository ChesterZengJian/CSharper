using ProAspNetMvc5_Filter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProAspNetMvc5_Filter.Filters
{
  public class CustomAuthorizeAttribute : AuthorizeAttribute
  {
    private string role;
    public CustomAuthorizeAttribute(string role)
    {
      this.role = role;
    }
    protected override bool AuthorizeCore(HttpContextBase httpContext)
    {
      if (httpContext.Session["User"] != null && ((User)httpContext.Session["User"]).UserName == role)
        return true;
      return false;
    }
  }
}