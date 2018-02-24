using Akroma.Web3.Model.HexTypes;
using Newtonsoft.Json;

namespace Akroma.Web3.Model
{
    public class Transaction
    {
        [JsonProperty(PropertyName = "hash")]
        public string Hash { get; set; }

        [JsonProperty(PropertyName = "nonce")]
        public HexBigInteger Nonce { get; set; }

        [JsonProperty(PropertyName = "blockHash")]
        public string BlockHash { get; set; }

        [JsonProperty(PropertyName = "blockNumber")]
        public HexBigInteger BlockNumber { get; set; }

        [JsonProperty(PropertyName = "transactionIndex")]
        public HexBigInteger TransactionIndex { get; set; }

        [JsonProperty(PropertyName = "from")]
        public string From { get; set; }

        [JsonProperty(PropertyName = "to")]
        public string To { get; set; }

        [JsonProperty(PropertyName = "value")]
        public HexBigInteger Value { get; set; }

        [JsonProperty(PropertyName = "gas")]
        public HexBigInteger Gas { get; set; }

        [JsonProperty(PropertyName = "gasPrice")]
        public HexBigInteger GasPrice { get; set; }
        
        [JsonProperty(PropertyName = "input")]
        public string Input { get; set; }

        // NOT FROM ETH
        //public int Timestamp { get; set; }
    }
}
