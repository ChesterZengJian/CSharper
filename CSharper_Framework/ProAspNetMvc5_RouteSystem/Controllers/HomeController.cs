using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProAspNetMvc5_RouteSystem.Controllers
{
  public class HomeController : Controller
  {
    // GET: Home
    public ActionResult Index(string id)
    {
      return Content($@"Namespace: ProAspNetMvc5_RouteSystem.Controllers
                        Controller: Home <br/>
                        Action: Index <br/>
                        id: {id}");
    }

    [Route("Test/{id:alpha:length(6)}")]
    public ActionResult Create(string id)
    {
      return Content($@"Namespace: ProAspNetMvc5_RouteSystem.Controllers
                             Controller: Home <br/>
                             Action: Index <br/>
                             id: {id}");
    }
    //public ActionResult Index(string id)
    //{
    //    return Content($@"Controller: Home <br/>
    //                     Action: Index <br/>
    //                     Id: {id}");
    //}
  }
}