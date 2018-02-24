using System.Threading.Tasks;
using Brickweave.Cqrs;
using Akroma.Domain.Blocks.Models;
using Akroma.Domain.Blocks.Services;

namespace Akroma.Domain.Blocks.Queries
{
    public class GetBlockByNumberHandler : IQueryHandler<GetBlockByNumber, Block>
    {
        private readonly IBlocksRepository _blocksRepository;

        public GetBlockByNumberHandler(IBlocksRepository blocksRepository)
        {
            _blocksRepository = blocksRepository;
        }

        public async Task<Block> HandleAsync(GetBlockByNumber query)
        {
            return await _blocksRepository.GetBlockByNumberAsync(query.Number);
        }
    }
}
