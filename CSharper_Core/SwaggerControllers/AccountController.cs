using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace SwaggerControllers
{
    [Route("api/[controller]")]
    public class AccountController:ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "This is SwaggerControllers.AccountController";
        }
    }
}
