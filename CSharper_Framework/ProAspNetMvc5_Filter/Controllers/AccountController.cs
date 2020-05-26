using ProAspNetMvc5_Filter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProAspNetMvc5_Filter.Controllers
{
  public class AccountController : Controller
  {
    public ActionResult Login()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Login(User user)
    {
      if ((user.UserName == "admin" && user.Password == "123456") 
        || (user.UserName == "traveller" && user.Password == "123456"))
      {
        Session["User"] = user;
        return RedirectToAction("Index", "Home");
      }
      else
      {
        return View();
      }
    }
  }
}