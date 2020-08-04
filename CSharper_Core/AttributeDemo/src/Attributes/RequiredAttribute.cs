using System;

namespace AttributeDemo.Attributes
{
    public class RequiredAttribute : AbstractValidateAttribute
    {
        public override bool Validate(object value)
        {
            if (value != null)
            {
                return true;
            }

            return false;
        }
    }
}