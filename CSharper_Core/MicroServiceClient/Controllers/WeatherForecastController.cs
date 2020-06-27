using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Consul;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace MicroServiceClient.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        private const string url = "http://ConsulServiceDemo/weatherforecast";
        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            var consulClient = new ConsulClient(c =>
            {
                c.Address = new Uri("http://localhost:8500/");
                c.Datacenter = "dc1";
            });

            var uri = new Uri(url);
            var services = consulClient.Agent.Services().Result.Response.Where(s => s.Value.Service.Equals(uri.Host, StringComparison.OrdinalIgnoreCase)).ToArray();
            var agentService = services[new Random(DateTime.Now.Millisecond).Next(0, services.Count())].Value;
            var requestUrl = $"{uri.Scheme}://{agentService.Address}:{agentService.Port}{uri.PathAndQuery}";

            _logger.LogInformation($"{requestUrl} invoke");

            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(requestUrl);
            var content = await response.Content.ReadAsStringAsync();
            var serviceResult = JsonConvert.DeserializeObject<IEnumerable<WeatherForecast>>(content);
            return serviceResult;

            //var rng = new Random();
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = rng.Next(-20, 55),
            //    Summary = Summaries[rng.Next(Summaries.Length)]
            //})
            //.ToArray();
        }
    }
}
