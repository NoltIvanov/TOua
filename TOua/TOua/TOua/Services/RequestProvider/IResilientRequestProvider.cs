using System.Threading.Tasks;

namespace TOua.Services.RequestProvider {
    public interface IResilientRequestProvider {
        Task<TResult> GetAsync<TResult>(string uri);
    }
}
