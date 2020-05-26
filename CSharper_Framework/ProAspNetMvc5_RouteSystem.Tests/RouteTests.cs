using System;
using System.Web;
using System.Web.Routing;
using ProAspNetMvc5_RouteSystem.App_Start;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ProAspNetMvc5_RouteSystem.Tests
{
  [TestClass]
  public class RouteTests
  {
    [TestMethod]
    public void TestIncomingRoutes()
    {
      TestRouteMatch("~/Home/aIandex", "Home", "Index");
      //TestRouteMatch("~/One/Two", "One", "Two");

      //TestRouteFail("~/Home/Index/1/2");
      //TestRouteFail("~/Home");
      //TestRouteFail("~/aHome/aa");

    }

    private void TestRouteFail(string url)
    {
      RouteCollection routes = new RouteCollection();
      MyRoutesConfig.RegisterRoutes(routes);

      var result = routes.GetRouteData(CreateHttpContext(url));

      Assert.IsTrue(result == null || result.Route == null);
    }

    private void TestRouteMatch(string url, string controller, string action, object routeProperties = null, string httpMethod = "GET")
    {
      RouteCollection routes = new RouteCollection();
      MyRoutesConfig.RegisterRoutes(routes);

      RouteData result = routes.GetRouteData(CreateHttpContext(url, httpMethod));

      Assert.IsNotNull(result);
      Assert.IsTrue(TestIncomingRouteResult(result, controller, action, routeProperties));
    }

    private bool TestIncomingRouteResult(RouteData routeResult, string controller, string action, object propertySet = null)
    {
      Func<object, object, bool> valCompare = (v1, v2) => { return StringComparer.InvariantCultureIgnoreCase.Compare(v1, v2) == 0; };

      bool result = valCompare(routeResult.Values["controller"], controller) && valCompare(routeResult.Values["action"], action);

      if (propertySet != null)
      {
        var propertyInfos = propertySet.GetType().GetProperties();
        foreach (var propertyInfo in propertyInfos)
        {
          if (!(routeResult.Values.ContainsKey(propertyInfo.Name) && valCompare(routeResult.Values[propertyInfo.Name], propertyInfo.GetValue(propertySet, null))))
          {
            result = false;
            break;
          }
        }
      }

      return result;
    }

    private HttpContextBase CreateHttpContext(string targetUrl = null, string httpMethod = "GET")
    {
      Mock<HttpRequestBase> mockRequest = new Mock<HttpRequestBase>();
      mockRequest.Setup(m => m.AppRelativeCurrentExecutionFilePath).Returns(targetUrl);
      mockRequest.Setup(m => m.HttpMethod).Returns(httpMethod);

      Mock<HttpResponseBase> mockResponse = new Mock<HttpResponseBase>();
      mockResponse.Setup(m => m.ApplyAppPathModifier(It.IsAny<string>())).Returns<string>(s => s);

      Mock<HttpContextBase> mockContext = new Mock<HttpContextBase>();
      mockContext.Setup(m => m.Request).Returns(mockRequest.Object);
      mockContext.Setup(m => m.Response).Returns(mockResponse.Object);
      return mockContext.Object;
    }

  }
}
