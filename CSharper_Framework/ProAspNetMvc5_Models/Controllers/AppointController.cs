using ProAspNetMvc5_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProAspNetMvc5_Models.Controllers
{
  public class AppointController : Controller
  {
    // GET: Appoint
    public ActionResult Create()
    {
      return View(new Appointment { Date = DateTime.Now });
    }
    [HttpPost]
    public ActionResult Create(Appointment appointment)
    {
      //if (string.IsNullOrEmpty(appointment.ClientName))
      //{
      //  ModelState.AddModelError("ClientName", "Please entry your name");
      //}
      //if (!appointment.TermsAccepted)
      //{
      //  ModelState.AddModelError("", "Model Error");
      //  ModelState.AddModelError("TermsAccepted", "You must accept the terms");
      //}

      if (ModelState.IsValid)
      {
        return View(nameof(Details), appointment);
      }
      return View();
    }

    public ActionResult Details(Appointment appointment)
    {
      return View(appointment);
    }
  }
}