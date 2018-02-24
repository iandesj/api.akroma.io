using System.Threading.Tasks;
using Akroma.Web3.Model;

namespace Akroma.Web3
{
    public interface IHttpClientAbstraction
    {
        Task<GethResponse<T>> PostAsync<T>(string method, params dynamic[] items);
    }
}
