using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMapperDemo.Models
{
    public class Order
    {
        public ActionResult<string> Get()
        {
            return "Orders";
        }
    }
}
