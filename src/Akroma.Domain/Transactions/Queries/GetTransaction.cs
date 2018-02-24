using Brickweave.Cqrs;
using Akroma.Domain.Transactions.Models;

namespace Akroma.Domain.Transactions.Queries
{
    public class GetTransaction : IQuery<Transaction>
    {
        public GetTransaction(string hash)
        {
            Hash = hash;
        }

        public string Hash { get; }
    }
}
