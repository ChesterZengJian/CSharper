using System;

namespace AttributeDemo.Attributes
{
    public class ValidateAttribute : AbstractValidateAttribute
    {
        private int MaxLength { get; }

        public ValidateAttribute(int maxLength)
        {
            MaxLength = maxLength;
        }

        public override bool Validate(object obj)
        {
            return obj.ToString().Length < MaxLength;
        }
    }
}