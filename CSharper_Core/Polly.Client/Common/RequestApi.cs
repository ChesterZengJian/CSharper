using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Polly.Client.Common
{
    public class RequestApi
    {
        [CustomPollyRetry]
        [CustomPollyFallback]
        public virtual string InvokeApi(string url)
        {
            using var httpClient = new HttpClient();
            var responseMessage = httpClient.GetAsync(url).Result;

            if (responseMessage.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception();
            }

            var responseContent = responseMessage.Content.ReadAsStringAsync().Result;
            return responseContent;
        }
    }
}