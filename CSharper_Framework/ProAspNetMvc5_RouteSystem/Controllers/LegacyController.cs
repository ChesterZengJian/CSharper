using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProAspNetMvc5_RouteSystem.Controllers
{
    public class LegacyController : Controller
    {
        // GET: Legacy
        public ActionResult Index(string legacyURL)
        {
            return View((object)legacyURL);
        }
    }
}