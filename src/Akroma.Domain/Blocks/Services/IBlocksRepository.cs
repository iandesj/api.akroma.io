using System.Collections.Generic;
using System.Threading.Tasks;
using Akroma.Domain.Blocks.Models;

namespace Akroma.Domain.Blocks.Services
{
    public interface IBlocksRepository
    {
        Task<IEnumerable<Block>> GetBlocksAsync(int limit);
        Task<Block> GetBlockByNumberAsync(int number);
        Task<Block> GetBlockByHashAsync(string hash);
    }
}
