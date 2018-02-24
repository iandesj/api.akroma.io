using Brickweave.Cqrs;
using Akroma.Domain.Blocks.Models;

namespace Akroma.Domain.Blocks.Queries
{
    public class GetBlockByHash : IQuery<Block>
    {
        public GetBlockByHash(string hash)
        {
            Hash = hash;
        }

        public string Hash { get; }
    }
}
