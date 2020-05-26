using System;
using System.Web.Mvc;
using ProAspNetMvc5_ControllerAndAction.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProAspNetMvc5_ControllerAndAction.Tests
{
  [TestClass]
  public class ActionTests
  {
    [TestMethod]
    public void ViewResultTest()
    {
      ExampleController target = new ExampleController();

      ViewResult result = target.ViewResult();

      Assert.AreEqual("MyView", result.ViewName);
    }

    [TestMethod]
    public void ViewSelectionTest()
    {
      ExampleController target = new ExampleController();

      ViewResult result = target.ViewSelection();

      Assert.AreEqual("", result.ViewName);
      Assert.IsInstanceOfType(result.ViewData.Model, typeof(System.DateTime));
    }

    [TestMethod]
    public void ViewBagsTest()
    {
      ExampleController target = new ExampleController();

      ViewResult result = target.ViewBags();

      Assert.AreEqual("", result.ViewName);
      Assert.AreEqual("Hello", result.ViewBag.Message);
    }

    [TestMethod]
    public void RedirectTest()
    {
      ExampleController target = new ExampleController();

      RedirectResult result = target.Redirect();

      Assert.IsTrue(result.Permanent);
      Assert.AreEqual("/Example/Index", result.Url);
    }

    [TestMethod]
    public void RedirectRouteTest()
    {
      ExampleController target = new ExampleController();

      RedirectToRouteResult result = target.RedirectRoute();

      Assert.IsFalse(result.Permanent);
      Assert.AreEqual("Example", result.RouteValues["controller"]);
      Assert.AreEqual("Index", result.RouteValues["Action"]);
      Assert.AreEqual("MyID", result.RouteValues["ID"]);
    }

    [TestMethod]
    public void StatusCodeTest()
    {
      ExampleController target = new ExampleController();

      HttpStatusCodeResult result = target.StatusCode();

      Assert.AreEqual(404, result.StatusCode);
    }
  }
}
