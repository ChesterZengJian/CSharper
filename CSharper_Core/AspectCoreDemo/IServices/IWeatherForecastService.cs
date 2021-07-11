using System.Collections.Generic;
using AspectCoreDemo.Attributes;

namespace AspectCoreDemo.IServices
{
    public interface IWeatherForecastService
    {
        [TimeConsumingStatistic]
        IEnumerable<WeatherForecast> GetWeatherForecasts();
    }
}