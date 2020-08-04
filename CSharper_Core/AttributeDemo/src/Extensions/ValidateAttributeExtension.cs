using AttributeDemo.Attributes;
using System;
using System.Reflection;

namespace AttributeDemo.Extensions
{
    public class ValidateAttributeExtension
    {
        public static void ValidateMaxLength<T>(T t)
        {
            var type = t.GetType();
            foreach (var property in type.GetProperties())
            {
                if (property.IsDefined(typeof(ValidateAttribute), true))
                {
                    var validation = (ValidateAttribute)property.GetCustomAttribute(typeof(ValidateAttribute));
                    if (validation.Validate(property.GetValue(t)))
                    {
                        Console.WriteLine("Successfully");
                    }
                    else
                    {
                        Console.WriteLine("Failed");
                    }
                }

            }
        }

        public static void Validate<T>(T t)
        {
            var type = t.GetType();
            foreach (var property in type.GetProperties())
            {
                if (property.IsDefined(typeof(AbstractValidateAttribute), true))
                {
                    var validation = (AbstractValidateAttribute)property.GetCustomAttribute(typeof(AbstractValidateAttribute));
                    if (validation != null && validation.Validate(property.GetValue(t)))
                    {
                        Console.WriteLine("Successfully");
                    }
                    else
                    {
                        Console.WriteLine("Failed");
                    }
                }

            }
        }
    }
}