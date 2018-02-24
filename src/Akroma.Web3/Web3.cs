using System;
using System.Dynamic;
using System.Globalization;
using System.Threading.Tasks;
using Akroma.Web3.Model;
using Akroma.Web3.Model.HexTypes;

namespace Akroma.Web3
{
    public class Web3
    {
        //TODO: support providers.
        public static string Url;
        private static HttpClientAbstraction _client;

        public Web3(string url = "http://localhost:8545")
        {
            Url = url;
            _client = new HttpClientAbstraction();
        }

        public Eth Eth => new Eth(_client);
    }

    public class Eth
    {
        private readonly HttpClientAbstraction _client;

        public Eth(HttpClientAbstraction client)
        {
            _client = client;
        }
        public async Task<GethResponse<bool>> Syncing()
        {
            return await _client.PostAsync<bool>(Web3Methods.EthSyncing);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number">integer of a block number, or the string "earliest", "latest" or "pending"</param>
        /// <returns>Block transactions (full transaction data)</returns>
        public async Task<GethResponse<BlockWithTransactions>> GetBlockByNumberWithTransactions(string number = "latest")
        {
            object toGet = number;
            if (number != "latest")
            {
                toGet = string.Format("0x{0:X}", int.Parse(number));
            }
            return await _client.PostAsync<BlockWithTransactions>(Web3Methods.EthGetBlockByNumber, toGet, true);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="number">integer of a block number, or the string "earliest", "latest" or "pending"</param>
        /// <returns>Block w/ transaction ids (not full transaction data)</returns>
        public async Task<GethResponse<Block>> GetBlockByNumber(string number = "latest")
        {
            return await _client.PostAsync<Block>(Web3Methods.EthGetBlockByNumber, number, false);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="address"></param>
        /// <returns>amount in eth/aka</returns>
        public async Task<GethResponse<string>> GetBalance(string address)
        {
            var response = await _client.PostAsync<string>(Web3Methods.EthGetBalance, address, "latest");
            response.Result = UnitConversion.Convert.FromWei(new HexBigInteger(response?.Result)).ToString(CultureInfo.InvariantCulture);
            return response;
        }


    }
}
