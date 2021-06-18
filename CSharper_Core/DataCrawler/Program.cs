using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Microsoft.Extensions.Configuration;

namespace DataCrawler
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var appSetting = config.GetSection(nameof(AppSetting)).Get<AppSetting>();

            using var httpClient = new HttpClient();
            var httpResponseMessage = await httpClient.GetAsync(appSetting.Url);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var html = await httpResponseMessage.Content.ReadAsStringAsync();
                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(html);
                // XPath: //*[@id="navitems-group1"]/li[3]/a
                var path = "//*[@id='navitems-group1']/li[3]/a";
                var nodes = htmlDocument.DocumentNode.SelectNodes(path);
                Console.WriteLine(nodes.FirstOrDefault());
            }
        }
    }
}
