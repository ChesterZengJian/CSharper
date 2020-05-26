using ProAspNetMvc5_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProAspNetMvc5_Models.Controllers
{
  public class HomeController : Controller
  {
    private Person[] personData =
    {
      new Person{PersonId=1,FirstName="Adam",LastName="Freeman",Role=Role.Admin}
      ,new Person{PersonId=2,FirstName="Jacqui",LastName="Griffyth",Role=Role.Admin}
      ,new Person{PersonId=3,FirstName="John",LastName="Smith",Role=Role.Admin}
      ,new Person{PersonId=4,FirstName="Anne",LastName="Jones",Role=Role.Admin}
    };
    // GET: Home
    public ActionResult Index()
    {
      return View(personData);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Person person)
    {
      return View("Details", person);
    }

    public ActionResult Details(int id = 1)
    {
      Person person = personData.FirstOrDefault(m => m.PersonId == id);
      return View(person);
    }

    public ActionResult DisplaySummary([Bind(Prefix = "HomeAddress", Exclude = "City")]Address address)
    {
      return View(address);
    }
  }
}