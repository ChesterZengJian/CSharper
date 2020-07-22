下面代码是可以触发重试的

```c#
var retryPolicy = Policy.Handle<Exception>().Retry(3, (ex, count) =>
{
    Console.WriteLine("=================================");
    Console.WriteLine($"Retry:{count}");
    Console.WriteLine("=================================");
});


retryPolicy.Execute(() =>
{
    var httpClient = _httpClientFactory.CreateClient();
    var responseMessage = httpClient.GetAsync("http://localhost:8005/weatherforecast").Result;

    if (responseMessage.StatusCode != System.Net.HttpStatusCode.OK)
    {
        throw new Exception();
    }

    var responseContent = responseMessage.Content.ReadAsStringAsync().Result;
    Console.WriteLine(responseContent);
    return JsonConvert.DeserializeObject<IEnumerable<WeatherForecast>>(responseContent);
});
```

但是如果用 async和await 就不行

```c#
var retryPolicy = Policy.Handle<Exception>().Retry(3, (ex, count) =>
{
    Console.WriteLine("=================================");
    Console.WriteLine($"Retry:{count}");
    Console.WriteLine("=================================");
});


await retryPolicy.Execute(async () =>
{
    var httpClient = _httpClientFactory.CreateClient();
    var responseMessage = await httpClient.GetAsync("http://localhost:8005/weatherforecast");

    if (responseMessage.StatusCode != System.Net.HttpStatusCode.OK)
    {
        throw new Exception();
    }

    var responseContent = await responseMessage.Content.ReadAsStringAsync();
    Console.WriteLine(responseContent);
    return JsonConvert.DeserializeObject<IEnumerable<WeatherForecast>>(responseContent);
});
```

