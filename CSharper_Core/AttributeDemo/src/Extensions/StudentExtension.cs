using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using AttributeDemo.Attributes;
using AttributeDemo.Models;

namespace AttributeDemo.Extensions
{
    public static class StudentExtension
    {
        public static void Required(this Student student)
        {
            foreach (var property in student.GetType().GetProperties())
            {
                if (!property.IsDefined(typeof(AbstractValidateAttribute), true)) continue;

                var requiredAttr = property.GetCustomAttribute<AbstractValidateAttribute>(true);
                if (requiredAttr.Validate(property.GetValue(student)))
                {
                    Console.WriteLine("Required successfully");
                    return;
                }

                Console.WriteLine("Required failed");
            }

        }
    }
}