using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;

namespace CSRedisDemo.Controllers
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

        [HttpGet]
        public async Task<string> Get()
        {
            await RedisHelper.SetAsync("Hello CSRedis", "First time to use csredis");

            var value = await RedisHelper.GetAsync("Hello CSRedis");
            Console.WriteLine($"string get '{value}'");
            Console.WriteLine();

            await RedisHelper.RPushAsync("list", "first element");
            await RedisHelper.LPushAsync("list", "left of the first element");
            Console.WriteLine($"first element '{await RedisHelper.LPopAsync("list")}'");
            Console.WriteLine();

            RedisHelper.HSet("hash sets", "key 1", "value 1");
            RedisHelper.HSet("hash sets", "key 2", "value 2");
            RedisHelper.HSet("hash sets", "key 3", "value 3");
            Console.WriteLine($"key 1 is '{await RedisHelper.HGetAsync("hash sets", "key 1")}'");
            Console.WriteLine();

            RedisHelper.SAdd("sets", "key 1", "key 2");
            Console.WriteLine($"sets has '{string.Join(",", (await RedisHelper.SScanAsync("sets", 0)).Items) }'");

            RedisHelper.ZAdd("Quiz", (79, "Math"));
            RedisHelper.ZAdd("Quiz", (98, "English"));
            RedisHelper.ZAdd("Quiz", (87, "Algorithm"));
            RedisHelper.ZAdd("Quiz", (84, "Database"));
            RedisHelper.ZAdd("Quiz", (59, "Operation System"));
            // Get the count of elements
            Console.WriteLine($"Sort set count is {RedisHelper.ZCard("Quiz")}");
            // Get elements within the range
            Console.WriteLine($"90-100:{string.Join(',', RedisHelper.ZRangeByScore("Quiz", 90, 100))}");
            // Gets all the elements of the collection and sorts them in ascending order
            Console.WriteLine("All elements:");
            foreach (var quiz in RedisHelper.ZRangeWithScores("Quiz", 0, -1))
            {
                Console.WriteLine($"\t{quiz.member}'s score is {quiz.score}");
            }
            // Removes elements from the collection
            Console.WriteLine($"Remove {RedisHelper.ZRem("Quiz", "Math")} elements");
            ;


            //RedisHelper.Subscribe(("chan1", msg => Console.WriteLine(msg.Body)), ("chan1", msg => Console.WriteLine(msg.Body)));
            //RedisHelper.PSubscribe()

            return value;
        }
    }
}
