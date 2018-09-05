using System.Threading.Tasks;
using TOua.Models.Rests.Requests;
using TOua.Models.Rests.Responses;

namespace TOua.Services.RequestProvider {
    public interface IRequestProvider {

        Task<TResponse> GetAsync<TRequest, TResponse>(TRequest request)
            where TRequest : class, IRequest
            where TResponse : class, IResponse;
    }
}
