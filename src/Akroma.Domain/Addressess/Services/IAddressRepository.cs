using System.Threading.Tasks;
using Akroma.Domain.Addressess.Model;

namespace Akroma.Domain.Addressess.Services
{
    public interface IAddressRepository
    {
        Task<Address> GetAddressAsync(string address, int page = 0);
    }


}
