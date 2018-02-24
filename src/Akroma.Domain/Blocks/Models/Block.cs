using System.Collections.Generic;

namespace Akroma.Domain.Blocks.Models
{
    public class Block
    {
        public Block(int number, string hash, string parentHash, string nonce, string sha3Uncles, string logsBloom,
            string transactionsRoot, string stateRoot, string miner, string difficulty, string totalDifficulty, long size,
            string extraData, long gasLimit, long gasUsed, long timestamp, IEnumerable<string> uncles)
        {
            Number = number;
            Hash = hash;
            ParentHash = parentHash;
            Nonce = nonce;
            Sha3Uncles = sha3Uncles;
            LogsBloom = logsBloom;
            TransactionsRoot = transactionsRoot;
            StateRoot = stateRoot;
            Miner = miner;
            Difficulty = difficulty;
            TotalDifficulty = totalDifficulty;
            Size = size;
            ExtraData = extraData;
            GasLimit = gasLimit;
            GasUsed = gasUsed;
            Timestamp = timestamp;
            Uncles = uncles;
        }

        public int Number { get; }
        public string Hash { get; }
        public string ParentHash { get; }
        public string Nonce { get; }
        public string Sha3Uncles { get; }
        public string LogsBloom { get; }
        public string TransactionsRoot { get; }
        public string StateRoot { get; }
        public string Miner { get; }
        public string Difficulty { get; }
        public string TotalDifficulty { get; }
        public long Size { get; }
        public string ExtraData { get; }
        public long GasLimit { get; }
        public long GasUsed { get; }
        public long Timestamp { get; }
        public IEnumerable<string> Uncles { get; }
    }
}
