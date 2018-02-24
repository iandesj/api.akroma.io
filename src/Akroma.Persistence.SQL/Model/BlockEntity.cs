using System.Collections.Generic;
using System.Linq;

namespace Akroma.Persistence.SQL.Model
{
    public class BlockEntity : BaseEntity
    {
        public int Number { get; set; }
        public string Hash { get; set; }
        public string ParentHash { get; set; }
        public string Nonce { get; set; }
        public string Sha3Uncles { get; set; }
        public string LogsBloom { get; set; }
        public string TransactionsRoot { get; set; }
        public string StateRoot { get; set; }
        public string Miner { get; set; }
        public string Difficulty { get; set; }
        public string TotalDifficulty { get; set; }
        public long Size { get; set; }
        public string ExtraData { get; set; }
        public long GasLimit { get; set; }
        public long GasUsed { get; set; }
        public long Timestamp { get; set; }
        public ICollection<UncleEntity> Uncles { get; set; } = new List<UncleEntity>();

        public Domain.Blocks.Models.Block ToBlock()
        {
            return new Domain.Blocks.Models.Block(this.Number,
                this.Hash,
                ParentHash,
                Nonce,
                Sha3Uncles,
                LogsBloom,
                TransactionsRoot,
                StateRoot,
                Miner,
                Difficulty,
                TotalDifficulty,
                Size,
                ExtraData,
                GasLimit,
                GasUsed,
                Timestamp,
                Uncles.Select(x=>x.Data));
        }
    }
}
