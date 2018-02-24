using Akroma.Domain.Addressess.Model;
using Brickweave.Cqrs;

namespace Akroma.Domain.Addressess.Queries
{
    public class GetAddress : IQuery<Address>
    {
        public GetAddress(string address, int page)
        {
            Address = address;
            Page = page;
        }
        public string Address { get; }
        public int Page { get; }
    }
}
