using System;

namespace PartialClassDemo
{
    public partial class Person
    {
        public void SayHello()
        {
            Console.WriteLine(m_name);
        }
    }
}