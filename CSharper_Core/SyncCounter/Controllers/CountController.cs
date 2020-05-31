using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace SyncCounter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountController : ControllerBase
    {
        private readonly IHubContext<CountHub,ICountClient> _countHubContext;
        public CountController(IHubContext<CountHub,ICountClient> countHubContext)
        {
            _countHubContext = countHubContext;
        }

        //[HttpPost]
        //public async Task<IActionResult> Post()
        //{
        //    await _countHubContext.Clients.All.SendAsync("someFunc", new { random = "abcd" });
        //    return Accepted(1);
        //}

        //[HttpGet]
        //public async Task<string> Get()
        //{
        //    await _countHubContext.Clients.All.SendAsync("someFunc", new { random = "abcd" });

        //    return "Test SignalR";
        //}

        [HttpGet]
        public async Task<string> Get()
        {
            await _countHubContext.Clients.All.SendSomething("Someone get things");

            return "Test SignalR";
        }
    }
}