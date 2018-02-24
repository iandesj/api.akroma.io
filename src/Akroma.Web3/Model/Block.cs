using System;
using System.Collections.Generic;
using Akroma.Web3.Model.HexTypes;
using Newtonsoft.Json;

namespace Akroma.Web3.Model
{
    public class Block
    {
        [JsonProperty(PropertyName = "number")]
        public HexBigInteger Number { get; set; }

        [JsonProperty(PropertyName = "hash")]
        public string Hash { get; set; }

        [JsonProperty(PropertyName = "parentHash")]
        public string ParentHash { get; set; }

        [JsonProperty(PropertyName = "nonce")]
        public string Nonce { get; set; }

        [JsonProperty(PropertyName = "sha3Uncles")]
        public string Sha3Uncles { get; set; }

        [JsonProperty(PropertyName = "logsBloom")]
        public string LogsBloom { get; set; }

        [JsonProperty(PropertyName = "transactionsRoot")]
        public string TransactionsRoot { get; set; }

        [JsonProperty(PropertyName = "stateRoot")]
        public string StateRoot { get; set; }

        [JsonProperty(PropertyName = "miner")]
        public string Miner { get; set; }

        [JsonProperty(PropertyName = "difficulty")]
        public HexBigInteger Difficulty { get; set; }

        [JsonProperty(PropertyName = "totalDifficulty")]
        public HexBigInteger TotalDifficulty { get; set; }

        
        [JsonProperty(PropertyName = "extraData")]
        public string ExtraData { get; set; }

        [JsonProperty(PropertyName = "size")]
        public HexBigInteger Size { get; set; }

        [JsonProperty(PropertyName = "gasLimit")]
        public HexBigInteger GasLimit { get; set; }

        [JsonProperty(PropertyName = "gasUsed")]
        public HexBigInteger GasUsed { get; set; }

        [JsonProperty(PropertyName = "timestamp")]
        public HexBigInteger Timestamp { get; set; }

        [JsonProperty(PropertyName = "transactions")]
        public virtual ICollection<string> Transaction { get; set; } = new List<string>();

        [JsonProperty(PropertyName = "uncles")]
        public ICollection<string> Uncles { get; set; } = new List<string>();
    }
}
