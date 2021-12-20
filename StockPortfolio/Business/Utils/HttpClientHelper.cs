using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StockPortfolio.Business.Utils
{
    public static class HttpClientHelper
    {
        public static async Task<HttpResponseMessage> SendRequestAsync(object payload, HttpClient httpClient, HttpMethod method, string requestUri)
        {
            var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(method, requestUri: requestUri)
            {
                Content = content 
            };
            return await httpClient.SendAsync(request);
        }
    }
}
