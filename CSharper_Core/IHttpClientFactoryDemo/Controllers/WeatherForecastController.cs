using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace IHttpClientFactoryDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        //private readonly IHttpClientFactory _httpClientFactory;
        //private const string baseUrl = "http://localhost:64954/weatherforecast";
        //public WeatherForecastController(IHttpClientFactory httpClientFactory)
        //{
        //    _httpClientFactory = httpClientFactory;

        //}

        private readonly WeatherForecastService _weatherForecastService;
        public WeatherForecastController(WeatherForecastService weatherForecastService)
        {
            _weatherForecastService = weatherForecastService;

        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            //var request = new HttpRequestMessage(HttpMethod.Get, baseUrl);

            //var client = _httpClientFactory.CreateClient("WeatherForecast");
            //var httpResponse = await client.GetAsync("weatherforecast");
            //if (httpResponse.IsSuccessStatusCode)
            //{
            //    var responseContent = await httpResponse.Content.ReadAsStringAsync();
            //    return JsonConvert.DeserializeObject<IEnumerable<WeatherForecast>>(responseContent);
            //}

            //return Array.Empty<WeatherForecast>();

            return await _weatherForecastService.Get();
        }
    }

    public class WeatherForecastService
    {
        private readonly HttpClient m_client;
        public WeatherForecastService(HttpClient client)
        {
            client.BaseAddress = new Uri("http://localhost:64954");
            client.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
            m_client = client;
        }

        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            var httpResponse = await m_client.GetAsync("weatherforecast");
            if (httpResponse.IsSuccessStatusCode)
            {
                var responseContent = await httpResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<WeatherForecast>>(responseContent);
            }

            return Array.Empty<WeatherForecast>();
        }
    }
}
