using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMapperDemo.Models
{
    public class Order
    {
        public string Id { get; set; }
    }

    public class OrderDTO
    {
        public string Id { get; set; }
    }
}
