using Newtonsoft.Json;

namespace Akroma.Web3.Model
{
    public class GethResponse<T>
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "jsonrpc")]
        public string Jsonrpc = "2.0";
        
        [JsonProperty(PropertyName = "result")]
        public T Result { get; set; }
    }


}
