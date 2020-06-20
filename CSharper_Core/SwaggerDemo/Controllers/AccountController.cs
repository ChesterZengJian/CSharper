using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SwaggerDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        [HttpGet]
        public string Get()
        {
            return "All account";
        }

        [HttpGet("{id}")]
        public string Get(string id)
        {
            return "one accoutn";
        }

        [HttpPost]
        public string Create(string account)
        {
            return "create account";
        }

        [HttpPut("{account}")]
        public string Put(string account)
        {
            return "modify account";
        }

        [HttpPut]
        public string Put(int id)
        {
            return "modify account by id";
        }

        [HttpDelete]
        public string Delete(string id)
        {
            return "delete account";
        }
    }
}