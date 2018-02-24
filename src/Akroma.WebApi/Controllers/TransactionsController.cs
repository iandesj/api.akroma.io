using System.Collections.Generic;
using System.Threading.Tasks;
using Akroma.Domain.Transactions.Models;
using Akroma.Domain.Transactions.Queries;
using Brickweave.Cqrs;
using Microsoft.AspNetCore.Mvc;

namespace Akroma.WebApi.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly IDispatcher _dispatcher;

        public TransactionsController(IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        /// <summary>
        /// List transactions
        /// </summary>
        /// <param name="limit">The number of transactions to return (default: 50, min: 1, max: 100)</param>
        [ProducesResponseType(typeof(IEnumerable<Transaction>), 200)]
        [HttpGet, Route("transactions")]
        public async Task<IEnumerable<Transaction>> Get(int? limit)
        {
            return await _dispatcher.DispatchQueryAsync(new GetTransactions(limit));
        }

        /// <summary>
        /// Find transaction by hash
        /// </summary>
        /// <param name="hash">The transaction hash</param>
        [ProducesResponseType(typeof(Transaction), 200)]
        [ProducesResponseType(typeof(void), 404)]
        [HttpGet, Route("transactions/{hash}")]
        public async Task<Transaction> GetBlock(string hash)
        {
            return await _dispatcher.DispatchQueryAsync(new GetTransaction(hash));
        }
    }
}
