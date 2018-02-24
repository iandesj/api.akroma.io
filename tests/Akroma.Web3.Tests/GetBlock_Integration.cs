using System;
using System.Threading.Tasks;
using Akroma.Web3.Model.HexTypes;
using Xunit;
using Xunit.Abstractions;

namespace Akroma.Web3.Tests
{
    public class GetBlockIntegration
    {
        private readonly ITestOutputHelper _console;

        public GetBlockIntegration(ITestOutputHelper console)
        {
            _console = console;
        }

        [Fact]
        public async Task GetLatestBlockTest()
        {
            //https://github.com/ethereum/wiki/wiki/JSON-RPC#eth_getblockbynumber
            var web3 = new Web3();
            var block = await web3.Eth.GetBlockByNumberWithTransactions();
            _console.WriteLine(block.Result.Nonce);
        }

        [Fact]
        public async Task GetBlockByNumberTest()
        {
            //https://github.com/ethereum/wiki/wiki/JSON-RPC#eth_getblockbynumber
            var web3 = new Web3();
            var block = await web3.Eth.GetBlockByNumberWithTransactions("251980");
            _console.WriteLine(block.Result.Nonce);
        }
    }


    public class GetBalanceIntegration
    {
        private readonly ITestOutputHelper _console;

        public GetBalanceIntegration(ITestOutputHelper console)
        {
            _console = console;
        }

        [Fact]
        public async Task GetBalanceTest()
        {
            //https://github.com/ethereum/wiki/wiki/JSON-RPC#eth_getblockbynumber
            var web3 = new Web3();
            var block = await web3.Eth.GetBalance("0xbe1f96904efc9f64127b437c924e7969aa63099c");
            _console.WriteLine(block?.Result ?? "no response from geth");
        }

    }
}
