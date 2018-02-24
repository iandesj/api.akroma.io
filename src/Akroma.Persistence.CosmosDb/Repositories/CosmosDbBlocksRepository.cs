using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Akroma.Domain.Blocks.Models;
using Akroma.Domain.Blocks.Services;
using Akroma.Persistence.CosmosDb.Entities;

namespace Akroma.Persistence.CosmosDb.Repositories
{
    public class CosmosDbBlocksRepository: IBlocksRepository
    {
        private readonly IMongoCollection<BlockDocument> _mongoCollection;

        public CosmosDbBlocksRepository(IMongoCollection<BlockDocument> mongoCollection)
        {
            _mongoCollection = mongoCollection;
        }

        public async Task<IEnumerable<Block>> GetBlocksAsync(int limit)
        {
            var blockDocuments = await _mongoCollection
                .AsQueryable()
                .OrderByDescending(x => x.Timestamp)
                .Take(limit)
                .ToListAsync();

            return blockDocuments.Select(b => b.ToBlock());
        }

        public async Task<Block> GetBlockByNumberAsync(int number)
        {
            var blockDocument = await _mongoCollection
                .AsQueryable()
                .SingleAsync(b => b.Number == number);

            return blockDocument.ToBlock();
        }

        public async Task<Block> GetBlockByHashAsync(string hash)
        {
            var blockDocument = await _mongoCollection
                .AsQueryable()
                .SingleAsync(b => b.Hash == hash);

            return blockDocument.ToBlock();
        }
    }
}
