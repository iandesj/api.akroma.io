using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Akroma.Domain.Blocks.Models;
using Akroma.Domain.Blocks.Services;
using Microsoft.EntityFrameworkCore;

namespace Akroma.Persistence.SQL.Repositories
{
    public class SQLBlocksRepository: IBlocksRepository
    {
        private readonly AkromaContext _context;

        public SQLBlocksRepository(AkromaContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Block>> GetBlocksAsync(int limit)
        {
            var blockDocuments = await _context
                .Blocks
                .OrderByDescending(x => x.Number)
                .Take(limit)
                .ToListAsync();

            return blockDocuments.Select(b => b.ToBlock());
        }

        public async Task<Block> GetBlockByNumberAsync(int number)
        {
            var blockDocument = await _context
                .Blocks
                .AsQueryable()
                .SingleAsync(b => b.Number == number);

            return blockDocument.ToBlock();
        }

        public async Task<Block> GetBlockByHashAsync(string hash)
        {
            var blockDocument = await _context
                .Blocks
                .AsQueryable()
                .SingleAsync(b => b.Hash == hash);

            return blockDocument.ToBlock();
        }
    }
}
