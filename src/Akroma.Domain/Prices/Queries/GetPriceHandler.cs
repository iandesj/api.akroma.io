using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Akroma.Domain.Prices.Models;
using Brickweave.Cqrs;
using Newtonsoft.Json;

namespace Akroma.Domain.Prices.Queries
{
    public class GetPriceHandler : IQueryHandler<GetPrice, IEnumerable<Price>>
    {
        private static readonly HttpClient HttpClient = new HttpClient();

        public async Task<IEnumerable<Price>> HandleAsync(GetPrice query)
        {
            var response = await HttpClient.GetStringAsync(new Uri("https://stocks.exchange/api2/ticker"));
            var prices = JsonConvert.DeserializeObject<List<StocksPrice>>(response);
            var aka = prices.FirstOrDefault(x => x.market_name == "AKA_BTC");

            return new List<Price>
            {
                new Price()
                {
                    Id = "akroma",
                    Name = "Akroma",
                    Symbol = "AKA",
                    Value = decimal.Parse(aka.ask)
                }
            };
        }
    }
    public class StocksPrice
    {
        public string min_order_amount { get; set; }
        public string ask { get; set; }
        public string bid { get; set; }
        public string last { get; set; }
        public string lastDayAgo { get; set; }
        public string vol { get; set; }
        public string spread { get; set; }
        public string buy_fee_percent { get; set; }
        public string sell_fee_percent { get; set; }
        public string market_name { get; set; }
        public string updated_time { get; set; }
        public string server_time { get; set; }
    }


}
