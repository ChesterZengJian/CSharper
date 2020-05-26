using ProAspNetMvc5_Models.ModelBinders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProAspNetMvc5_Models.Models
{
  [ModelBinder(typeof(AddressBinder))]
  public class Address
  {
    public string Line1 { get; set; }
    public string Line2 { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
  }
}