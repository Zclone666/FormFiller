using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TestAppPir.Methods.Http
{
    public class Send<T>
    {
        public static async Task<string> Post(T Req, String Url)
        {
            HttpClient httpClient = new HttpClient()
            {
                BaseAddress = new Uri(Url),

            };
            string rq = Newtonsoft.Json.JsonConvert.SerializeObject(Req, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
            StringContent jsonContent = new StringContent(rq, Encoding.UTF8, "application/json");
            HttpRequestMessage httpRequestM = new HttpRequestMessage(HttpMethod.Post, Url);
            httpRequestM.Content = jsonContent;

            using HttpResponseMessage response = await httpClient.SendAsync(httpRequestM);

            var t = await response.Content.ReadAsStringAsync();
            return await response.Content.ReadAsStringAsync();
        }

        public static async Task<string> HttpGet(String Url)
        {
            HttpClient httpClient = new HttpClient()
            {
                BaseAddress = new Uri(Url),

            };

            HttpRequestMessage httpRequestM = new HttpRequestMessage(HttpMethod.Get, Url);


            using HttpResponseMessage response = await httpClient.SendAsync(httpRequestM);

            var t = await response.Content.ReadAsStringAsync();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
