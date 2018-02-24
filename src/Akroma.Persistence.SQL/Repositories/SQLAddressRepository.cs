using System;
using System.Linq;
using System.Threading.Tasks;
using Akroma.Domain.Addressess.Model;
using Akroma.Domain.Addressess.Services;
using Microsoft.EntityFrameworkCore;

namespace Akroma.Persistence.SQL.Repositories
{
    public class SQLAddressRepository : IAddressRepository
    {
        private readonly AkromaContext _context;

        public SQLAddressRepository(AkromaContext context)
        {
            _context = context;
        }
        public async Task<Address> GetAddressAsync(string address, int page = 0)
        {
            //CREATE INDEX transaction_index
            //    ON Transactions(Timestamp)
            //INCLUDE([To], [From])  -- TODO: Add this to migrations/local.
            var transactions = await _context
                .Transactions
                .AsNoTracking()
                .Where(x => x.From == address || x.To == address)
                .OrderByDescending(x => x.Timestamp)
                .Skip(page * 10)
                .Take(10)
                .Select(x => x.ToTransaction())
                .ToListAsync();

            var transacionCount = await _context
                .Transactions
                .AsNoTracking()
                .Where(x => x.From == address || x.To == address)
                .CountAsync();

            var transacionCountFrom = await _context
                .Transactions
                .AsNoTracking()
                .Where(x => x.From == address)
                .CountAsync();

            var transacionCountTo = await _context
                .Transactions
                .AsNoTracking()
                .Where(x => x.To == address)
                .CountAsync();

            var mined = await _context
                .Blocks
                .AsNoTracking()
                .Where(x => x.Miner == address)
                .CountAsync();
            
            var pages = (int)Math.Ceiling((double)transacionCount / 10);

            var adddress = new Address(address, "", mined, page, pages, transacionCount, transacionCountFrom, transacionCountTo, transactions);
            return adddress;
        }
    }
}
