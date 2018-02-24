using System.Collections.Generic;
using System.Threading.Tasks;
using Brickweave.Cqrs;
using Akroma.Domain.Blocks.Models;
using Akroma.Domain.Blocks.Services;
using System;

namespace Akroma.Domain.Blocks.Queries
{
    public class GetBlocksHandler : IQueryHandler<GetBlocks, IEnumerable<Block>>
    {
        private readonly IBlocksRepository _blocksRepository;

        public GetBlocksHandler(IBlocksRepository blocksRepository)
        {
            _blocksRepository = blocksRepository;
        }

        public async Task<IEnumerable<Block>> HandleAsync(GetBlocks query)
        {
            var limit = query.Limit ?? 50;
            limit = Math.Min(100, Math.Max(1, limit));

            return await _blocksRepository.GetBlocksAsync(limit);
        }
    }
}
