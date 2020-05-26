using ProAspNetMvc5_ControllerAndAction.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProAspNetMvc5_ControllerAndAction.Controllers
{
  public class RemoteDataController : Controller
  {
    // GET: RemoteData
    public async Task<ActionResult> Data()
    {
      string data = await new RemoteService().GetRemoteData();
      return Content(data);
    }
  }
}