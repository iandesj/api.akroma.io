using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Akroma.Domain.Transactions.Models;
using Akroma.Domain.Transactions.Services;
using Microsoft.EntityFrameworkCore;

namespace Akroma.Persistence.SQL.Repositories
{
    public class SQLTransactionsRepository : ITransactionsRepository
    {
        private readonly AkromaContext _context;

        public SQLTransactionsRepository(AkromaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsAsync(int limit)
        {
            var transactionDocuments = await _context
                .Transactions 
                .OrderByDescending(x => x.Timestamp)
                .Take(limit)
                .ToListAsync();

            return transactionDocuments.Select(t => t.ToTransaction());
        }

        public async Task<Transaction> GetTransactionAsync(string hash)
        {
            var transactionDocument = await _context
                .Transactions
                .AsQueryable()
                .SingleAsync(t => t.Hash == hash);

            return transactionDocument.ToTransaction();
        }
    }
}
