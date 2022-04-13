using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SyncCounter.Client.HostServices;

namespace SyncCounter.Client.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly SignalRHostService m_signalRService;

        public MessagesController(SignalRHostService signalRService)
        {
            m_signalRService = signalRService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            await m_signalRService.SendToServer();

            return Ok("Successfully");
        }
    }
}