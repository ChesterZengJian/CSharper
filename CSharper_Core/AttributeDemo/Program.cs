using AttributeDemo.Attributes;
using AttributeDemo.Models;
using System;
using AttributeDemo.Extensions;

namespace AttributeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var student = new Student
            {
                Id = "1",
                Name = "C"
            };
            student.Required();

            //CustomAttributeExtension.Show<Student>();

            //ValidateAttributeExtension.ValidateMaxLength<Student>(student);
            //ValidateAttributeExtension.Validate<Student>(student);

            Console.WriteLine("Hello World!");
        }
    }
}
