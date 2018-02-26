using Akroma.Domain.Transactions.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Akroma.Persistence.CosmosDb.Entities
{
    [BsonIgnoreExtraElements]
    public class TransactionDocument
    {
        [BsonElement("hash")]
        public string Hash { get; set; }

        [BsonElement("nonce")]
        public string Nonce { get; set; }

        [BsonElement("blockHash")]
        public string BlockHash { get; set; }

        [BsonElement("blockNumber")]
        public int BlockNumber { get; set; }

        [BsonElement("transactionIndex")]
        public int TransactionIndex { get; set; }

        [BsonElement("from")]
        public string From { get; set; }

        [BsonElement("to")]
        public string To { get; set; }

        [BsonElement("value")]
        public long Value { get; set; }

        [BsonElement("gas")]
        public string Gas { get; set; }

        [BsonElement("gasPrice")]
        public string GasPrice { get; set; }

        [BsonElement("timestamp")]
        public int Timestamp { get; set; }

        [BsonElement("input")]
        public string Input { get; set; }

        public Transaction ToTransaction()
        {
            return new Transaction(
                Hash, Nonce, BlockHash, BlockNumber, TransactionIndex, From,
                To, Value, Gas, GasPrice, Timestamp, Input
            );
        }
    }
}
