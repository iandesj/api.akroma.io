using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Akroma.Domain.Transactions.Models;
using Akroma.Domain.Transactions.Services;
using Akroma.Persistence.CosmosDb.Entities;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Akroma.Persistence.CosmosDb.Repositories
{
    public class CosmosDbTransactionsRepository : ITransactionsRepository
    {
        private readonly IMongoCollection<TransactionDocument> _mongoCollection;

        public CosmosDbTransactionsRepository(IMongoCollection<TransactionDocument> mongoCollection)
        {
            _mongoCollection = mongoCollection;
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsAsync(int limit)
        {
            var transactionDocuments = await _mongoCollection
                .AsQueryable()
                .OrderByDescending(x => x.Timestamp)
                .Take(limit)
                .ToListAsync();

            return transactionDocuments.Select(t => t.ToTransaction());
        }

        public async Task<Transaction> GetTransactionAsync(string hash)
        {
            var transactionDocument = await _mongoCollection
                .AsQueryable()
                .SingleAsync(t => t.Hash == hash);

            return transactionDocument.ToTransaction();
        }
    }
}
