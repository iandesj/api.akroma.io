using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Akroma.Domain.Blocks.Models;

namespace Akroma.Persistence.CosmosDb.Entities
{
    [BsonIgnoreExtraElements]
    public class BlockDocument
    {
        [BsonElement("number")]
        public int Number { get; set; }

        [BsonElement("hash")]
        public string Hash { get; set; }

        [BsonElement("parentHash")]
        public string ParentHash { get; set; }

        [BsonElement("nonce")]
        public string Nonce { get; set; }

        [BsonElement("sha3Uncles")]
        public string Sha3Uncles { get; set; }

        [BsonElement("logsBloom")]
        public string LogsBloom { get; set; }

        [BsonElement("transactionsRoot")]
        public string TransactionsRoot { get; set; }

        [BsonElement("stateRoot")]
        public string StateRoot { get; set; }

        [BsonElement("miner")]
        public string Miner { get; set; }

        [BsonElement("difficulty")]
        public string Difficulty { get; set; }

        [BsonElement("totalDifficulty")]
        public string TotalDifficulty { get; set; }

        [BsonElement("size")]
        public int Size { get; set; }

        [BsonElement("extraData")]
        public string ExtraData { get; set; }

        [BsonElement("gasLimit")]
        public long GasLimit { get; set; }

        [BsonElement("gasUsed")]
        public long GasUsed { get; set; }

        [BsonElement("timestamp")]
        public int Timestamp { get; set; }

        [BsonElement("uncles")]
        public IEnumerable<string> Uncles { get; set; }

        public Block ToBlock()
        {
            return new Block(
                Number, Hash, ParentHash, Nonce, Sha3Uncles, LogsBloom, TransactionsRoot,
                StateRoot, Miner, Difficulty, TotalDifficulty, Size, ExtraData, GasLimit,
                GasUsed, Timestamp, Uncles
            );
        }
    }
}
