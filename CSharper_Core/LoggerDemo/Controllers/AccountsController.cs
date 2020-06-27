using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LoggerDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly ILogger m_logger;

        public AccountsController(ILogger<AccountsController> logger)
        {
            m_logger = logger;
        }

        public string Get()
        {
            m_logger.LogInformation($"Log Info: This is the {nameof(AccountsController)}");
            return nameof(AccountsController);
        }
    }
}