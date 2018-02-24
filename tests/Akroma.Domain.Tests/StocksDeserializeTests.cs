using System;
using System.Collections.Generic;
using System.Linq;
using Akroma.Domain.Prices.Queries;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace Akroma.Domain.Tests
{
    public class StocksDeserializeTests
    {
        private readonly ITestOutputHelper _console;

        public StocksDeserializeTests(ITestOutputHelper console)
        {
            _console = console;
        }
        [Fact]
        public void CanDeserialize()
        {
            var response =
                @"[{""min_order_amount"":""0.00000010"",""ask"":""0.00003978"",""bid"":""0.0000253"",""last"":""0.00002702"",""lastDayAgo"":""0.0000252"",""vol"":""16193.46982122"",""spread"":""0"",""buy_fee_percent"":""0"",""sell_fee_percent"":""0"",""market_name"":""AKA_BTC"",""updated_time"":1519479906,""server_time"":1519479906}]";
            var prices = JsonConvert.DeserializeObject<List<StocksPrice>>(response);
            var first = prices.FirstOrDefault();
            _console.WriteLine(decimal.Parse(first.ask).ToString());
            
        }
    }
}
