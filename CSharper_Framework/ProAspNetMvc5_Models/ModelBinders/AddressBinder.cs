using ProAspNetMvc5_Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProAspNetMvc5_Models.ModelBinders
{
  public class AddressBinder : IModelBinder
  {
    public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
    {
      Address model = (Address)bindingContext.Model ?? new Address();
      model.City = GetValue(bindingContext, "City");
      model.Country = GetValue(bindingContext, "Country");
      return model;
    }

    private string GetValue(ModelBindingContext bindingContext, string name)
    {
      name = (bindingContext.ModelName == "" ? "" : bindingContext.ModelName + ".") + name;
      ValueProviderResult result = bindingContext.ValueProvider.GetValue(name);
      if (result == null || result.AttemptedValue == "")
      {
        return "<Not Specified>";
      }
      return (string)result.AttemptedValue;
    }
  }
}