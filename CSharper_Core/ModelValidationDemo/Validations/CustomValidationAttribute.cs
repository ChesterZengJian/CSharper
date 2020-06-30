using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ModelValidationDemo.Validations
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property)]
    public class CustomValidationAttribute : ValidationAttribute
    {

        public override bool IsValid(object value)
        {
            if (Convert.ToInt32(value) == 10)
            {
                return false;
            }

            return true;
        }
    }
}
