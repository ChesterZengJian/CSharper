using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consul;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MicroService01.Controllers
{
[Route("api/[controller]")]
[ApiController]
public class HealthController : ControllerBase
{
    private readonly ILogger _logger;

    public HealthController(ILogger<HealthController> logger)
    {
        _logger = logger;
    }

    public IActionResult Get()
    {
        _logger.LogInformation($"This is Health Check");
        return Ok();
    }
}
}