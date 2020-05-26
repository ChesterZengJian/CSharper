using ProAspNetMvc5_Models.ModelBinders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProAspNetMvc5_Models.ValueProviderFactories
{
  public class CustomValueProviderFactory : ValueProviderFactory
  {
    public override IValueProvider GetValueProvider(ControllerContext controllerContext)
    {
      return new CountryValueProvider();
    }
  }
}