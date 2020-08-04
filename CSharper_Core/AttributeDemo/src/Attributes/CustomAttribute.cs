using System;

namespace AttributeDemo.Attributes
{
    public class CustomAttribute : Attribute
    {
        public CustomAttribute() { }

        public CustomAttribute(int id) { }

        public CustomAttribute(string name) { }

        public int Id { get; set; }
        public string Name { get; set; }

        public void Do()
        {
            Console.WriteLine("Do something");
        }
    }
}