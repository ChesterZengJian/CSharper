using System;

namespace DelegateDemo.Delegates
{
    public class Fishermen
    {
        public void PullHook()
        {
            Console.WriteLine("Pull hook");
        }
    }

    public class Fish
    {
        public Action Handler { get; set; }
        public void Eat()
        {
            Handler?.Invoke();
        }
    }

    public class FishFloat
    {
        public void Move()
        {
            Console.WriteLine("Move Fish Float");
        }
    }
}