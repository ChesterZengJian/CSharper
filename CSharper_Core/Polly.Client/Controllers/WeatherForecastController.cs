using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Polly.Client.Common;

namespace Polly.Client.Controllers
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

        private readonly IHttpClientFactory _httpClientFactory;

        private readonly RequestApi _requestApi;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IHttpClientFactory httpClientFactory,
            RequestApi requestApi)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _requestApi = requestApi;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            {
                // var retryPolicy = Policy.Handle<Exception>().Retry(3, (ex, count) =>
                // {
                //     Console.WriteLine("=================================");
                //     Console.WriteLine($"Retry:{count}");
                //     Console.WriteLine("=================================");
                // });


                // retryPolicy.Execute(() =>
                //{
                //    var httpClient = _httpClientFactory.CreateClient();
                //    var responseMessage = httpClient.GetAsync("http://localhost:8005/weatherforecast").Result;

                //    if (responseMessage.StatusCode != System.Net.HttpStatusCode.OK)
                //    {
                //        throw new Exception();
                //    }

                //    var responseContent = responseMessage.Content.ReadAsStringAsync().Result;
                //    Console.WriteLine(responseContent);
                //    return JsonConvert.DeserializeObject<IEnumerable<WeatherForecast>>(responseContent);
                //});

                // return null;
            }

            {
                var proxyGenerator = new ProxyGenerator();
                var interceptor = new CustomInterceptor();
                var requestApi = proxyGenerator.CreateClassProxy<RequestApi>(interceptor);
                var responseContent = requestApi.InvokeApi("http://localhost:8005/weatherforecasta");
                return JsonConvert.DeserializeObject<IEnumerable<WeatherForecast>>(responseContent);
            }

            {
                //var proxyGenerator = new ProxyGenerator();
                //CustomInterceptor interceptor = new CustomInterceptor();
                //var commOnClass = proxyGenerator.CreateClassProxy<CommOnClass>(interceptor);
                //commOnClass.MethodInterceptor();
                //commOnClass.MethodNoInterceptor();
            }

            {
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
}
