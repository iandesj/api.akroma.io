using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Akroma.Web3.Model;
using Newtonsoft.Json;

namespace Akroma.Web3
{
    public class HttpClientAbstraction : IHttpClientAbstraction
    {
        private static readonly HttpClient HttpClient;

        static HttpClientAbstraction()
        {
            HttpClient = new HttpClient();
            HttpClient.DefaultRequestHeaders
                .Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


        /// <summary>
        /// Calls geth using http
        /// </summary>
        /// <param name="method">https://github.com/ethereum/go-ethereum/wiki/Management-APIs</param>
        /// <param name="items"></param>
        /// <returns></returns>
        //TODO: support non-http providers
        public async Task<GethResponse<T>> PostAsync<T>(string method, params object[] items)
        {
            var content = new GethRequest()
            {
                Method = method,
                Params = items,
            };

            var contentJson = JsonConvert.SerializeObject(content);
            Trace.WriteLine(contentJson);
            var response = await HttpClient.PostAsync(Web3.Url, new StringContent(contentJson, Encoding.UTF8, "application/json"));
            var responseString = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<GethResponse<T>>(responseString);
            return responseObject;
        }
    }
}
