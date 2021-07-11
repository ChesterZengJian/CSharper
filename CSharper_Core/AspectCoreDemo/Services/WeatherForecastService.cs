using System;
using System.Collections.Generic;
using System.Linq;
using AspectCoreDemo.Attributes;
using AspectCoreDemo.IServices;
using Microsoft.Extensions.Logging;

namespace AspectCoreDemo.Services
{

    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly ILogger<WeatherForecast> m_logger;

        private static readonly string[] _summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public WeatherForecastService(ILogger<WeatherForecast> logger)
        {
            m_logger = logger;
        }

        public IEnumerable<WeatherForecast> GetWeatherForecasts()
        {
            Console.WriteLine("Hello");
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = _summaries[rng.Next(_summaries.Length)]
            })
                .ToArray();
        }
    }
}