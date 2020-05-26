using ProAspNetMvc5_Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProAspNetMvc5_Models.Validations
{
  public class NoJoeOnMondaysAttribute : ValidationAttribute
  {
    public NoJoeOnMondaysAttribute()
    {
      ErrorMessage = "Joe cannot appointment on Mondays(Custom Model Validation)";
    }

    public override bool IsValid(object value)
    {
      if (!(value is Appointment appointment) 
        || string.IsNullOrEmpty(appointment.ClientName) 
        || appointment.Date == null)
      {
        return true;
      }
      return !(appointment.ClientName == "Joe" 
               && appointment.Date.DayOfWeek == DayOfWeek.Monday);
    }
  }
}