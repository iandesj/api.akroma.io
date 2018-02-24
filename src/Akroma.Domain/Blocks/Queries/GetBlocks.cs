using System.Collections.Generic;
using Brickweave.Cqrs;
using Akroma.Domain.Blocks.Models;

namespace Akroma.Domain.Blocks.Queries
{
    public class GetBlocks : IQuery<IEnumerable<Block>>
    {
        public GetBlocks(int? limit)
        {
            Limit = limit;
        }

        public int? Limit { get; }
    }
}
