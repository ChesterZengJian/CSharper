using DelegateDemo.Delegates;
using System;
using DelegateDemo.Extensions;
using DelegateDemo.Models;

namespace DelegateDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                //var customDelegate = new CustomDelegate();
                //customDelegate.Show();
            }

            {
                //var delegateMethod = new CustomDelegateExtension();
                //delegateMethod.Show();
            }

            {
                //EventStandard.Show();
            }

            {
                var customDelegateExtension = new Delegates.CustomDelegateExtension();
                customDelegateExtension.Show();
            }

            {
                //Compare<int>(1, 3, (t1, t2) => t1 > t2);
                //var p1 = new People
                //{
                //    Id = 1,
                //    Name = "Nick",
                //    Order = 1
                //};
                //var p2 = new People
                //{
                //    Id = 2,
                //    Name = "Chester",
                //    Order = 2
                //};
                //Compare<People>(p1, p2, (t1, t2) => t1.Order > t2.Order);
            }
        }

        public static void Compare<T>(T t1, T t2, Func<T, T, bool> predicate)
        {
            Console.WriteLine(predicate(t1, t2)
                ? $"{t1.ToString()} more than {t2.ToString()}"
                : $"{t1.ToString()} less than {t2.ToString()}");
        }
    }

    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
