using System;

namespace PartialClassDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var person=new Person("Chester");
            person.SayHello();
            Console.WriteLine("Hello World!");
        }
    }

    public partial class Person
    {
        private string m_name;

        public Person(string name)
        {
            m_name = name;
        }
    }


}
