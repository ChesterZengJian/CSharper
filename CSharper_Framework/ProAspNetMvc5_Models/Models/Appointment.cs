using ProAspNetMvc5_Models.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProAspNetMvc5_Models.Models
{
  //[NoJoeOnMondays]
  public class Appointment : IValidatableObject
  {
    public string ClientName { get; set; }
    [DataType(DataType.Date)]
    //[FutureDate(ErrorMessage = @"Please entry the date 
    //                              in the future(Custom Attribute Validation)")]
    public DateTime Date { get; set; }
    //[MustBeTrue(ErrorMessage = "You must accept the terms(Custom Attribute Validation)")]
    public bool TermsAccepted { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
      List<ValidationResult> errors = new List<ValidationResult>();

      if (string.IsNullOrEmpty(ClientName))
      {
        errors.Add(new ValidationResult("Please enter yourname"));
      }

      if (DateTime.Now > Date)
      {
        errors.Add(new ValidationResult("Please enter a date in the future"));
      }

      return errors;
    }
  }
}