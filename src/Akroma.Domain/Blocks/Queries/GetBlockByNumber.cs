using Brickweave.Cqrs;
using Akroma.Domain.Blocks.Models;

namespace Akroma.Domain.Blocks.Queries
{
    public class GetBlockByNumber : IQuery<Block>
    {
        public GetBlockByNumber(int number)
        {
            Number = number;
        }

        public int Number { get; }
    }
}
