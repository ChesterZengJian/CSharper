using AttributeDemo.Attributes;
using System;
using System.Reflection;

namespace AttributeDemo.Extensions
{
    public class CustomAttributeExtension
    {
        public static void Show<T>()
        {
            var type = typeof(T);
            if (type.IsDefined(typeof(CustomAttribute), false))
            {
                foreach (var attribute in type.GetCustomAttributes())
                {
                    var customAttribute = (CustomAttribute)attribute;
                    Console.WriteLine($"Id={customAttribute.Id}");
                    Console.WriteLine($"Id={customAttribute.Name}");
                }
            }

            foreach (var property in type.GetProperties())
            {
                
            }
        }
    }
}