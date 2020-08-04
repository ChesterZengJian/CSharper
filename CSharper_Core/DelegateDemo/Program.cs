using System;
using System.Collections.Generic;
using DelegateDemo.Delegates;
using DelegateDemo.src.Delegates;


namespace DelegateDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                //int.TryParse("2", out var result);

                //var people = new People();
                //people.Run();

                //Console.WriteLine("Hello World".MaxStrShow(2));
            }

            {
                var peoples = new List<People>()
                {
                    new People {Id = 1, Name = "p1"},
                    new People {Id = 2, Name = "p2"},
                    new People {Id = 3, Name = "p3"}
                };

                foreach (var people in peoples.PeopleWhere(p => p.Id >= 2 && p.Name == "p2"))
                {
                    Console.WriteLine(people.Id);
                }

            }

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
                //var customDelegateExtension = new Delegates.CustomDelegateExtension();
                //customDelegateExtension.Show();
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


            {
                //var fish = new Fish();
                //fish.Handler += new Fishermen().PullHook;
                //fish.Handler += new FishFloat().Move;
                //fish.Eat();
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
        private int State { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }

        public void Run()
        {
            Console.WriteLine("People run");
        }

        public override string ToString()
        {
            return this.Name;
        }
    }

    public static class PeopleExtension
    {
        public static void Run(this People people)
        {
            Console.WriteLine("People extension run");
        }

        public static List<People> PeopleWhere(this List<People> peoples, Predicate<People> predicate)
        {
            var newPeoples = new List<People>();
            foreach (var people in peoples)
            {
                if (predicate(people))
                {
                    newPeoples.Add(people);
                }
            }

            return newPeoples;
        }
    }

    public static class StringExtension
    {
        public static string MaxStrShow(this string str, int maxLength)
        {
            return str.Substring(0, maxLength);
        }
    }
}
