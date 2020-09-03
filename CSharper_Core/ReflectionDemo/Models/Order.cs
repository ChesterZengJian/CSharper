using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace ReflectionDemo.Models
{
    public class Order
    {
        public Order(string id)
        {
            Id = id;
        }

        public string Id { get; set; } = "Order1";

        public string Name { get; set; }

        public string User { get; set; }
    }

    public class User
    {
        public string Id { get; set; }
    }
}
