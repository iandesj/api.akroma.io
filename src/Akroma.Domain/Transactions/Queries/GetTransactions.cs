using System.Collections.Generic;
using Akroma.Domain.Transactions.Models;
using Brickweave.Cqrs;

namespace Akroma.Domain.Transactions.Queries
{
    public class GetTransactions: IQuery<IEnumerable<Transaction>>
    {
        public GetTransactions(int? limit)
        {
            Limit = limit;
        }

        public int? Limit { get; }
    }
}
