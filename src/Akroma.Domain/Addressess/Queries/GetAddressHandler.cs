using System.Threading.Tasks;
using Akroma.Domain.Addressess.Model;
using Akroma.Domain.Addressess.Services;
using Brickweave.Cqrs;

namespace Akroma.Domain.Addressess.Queries
{
    public class  GetAddressHandler: IQueryHandler<GetAddress, Address>
    {
        private readonly IAddressRepository _repository;

        public GetAddressHandler(IAddressRepository repository)
        {
            _repository = repository;
        }
        public async Task<Address> HandleAsync(GetAddress query)
        {
            var web3 = new Web3.Web3("https://rpc.akroma.io");
            var block = await web3.Eth.GetBalance(query.Address);
            

            var response = await _repository.GetAddressAsync(query.Address, query.Page);
            response.Balance = block.Result;
            return response;
        }
    }
}
