using System;
using System.Reflection.Emit;

namespace DelegateDemo.Models
{
    /// <summary>
    /// 发布事件
    /// </summary>
    public class EventStandard
    {
        public static void Show()
        {
            var fclass = new FrameworkEvent
            {
                Id = 1,
                Name = "vip",
                Price = 2342
            };

            fclass.PriceIncrease += new StudentInfo().Buy;
            fclass.PriceIncrease += new TeacherInfo().Buy;
            fclass.Price = 24325;
        }


    }

    public class StudentInfo
    {
        public void Buy(object sender, EventArgs e)
        {
            var frameworkClass = (FrameworkEvent)sender;
            var eventArgs = (FrameworkEventArgs)e;

            Console.WriteLine($"this is {frameworkClass.Name}");
            Console.WriteLine($"Old Price:{eventArgs.OldPrice}");
            Console.WriteLine($"New Price:{eventArgs.NewPrice}");

            Console.WriteLine("Student buy");
        }
    }

    public class TeacherInfo
    {
        public void Buy(object sender, EventArgs e)
        {
            var frameworkClass = (FrameworkEvent)sender;
            var eventArgs = (FrameworkEventArgs)e;

            Console.WriteLine($"this is {frameworkClass.Name}");
            Console.WriteLine($"Old Price:{eventArgs.OldPrice}");
            Console.WriteLine($"New Price:{eventArgs.NewPrice}");

            Console.WriteLine("Teacher buy");
        }
    }

    public class FrameworkEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int _price;
        public int Price
        {
            get => _price;
            set
            {
                if (value > _price)
                {
                    PriceIncrease?.Invoke(this, new FrameworkEventArgs
                    {
                        OldPrice = _price,
                        NewPrice = value
                    });
                }

                _price = value;
            }
        }

        public event EventHandler PriceIncrease;
    }

    public class FrameworkEventArgs : EventArgs
    {
        public int OldPrice { get; set; }
        public int NewPrice { get; set; }
    }
}