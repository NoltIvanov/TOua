using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TOua.Exceptions;
using TOua.Helpers;
using TOua.Models.Rests.Requests;
using TOua.Models.Rests.Responses;

namespace TOua.Services.RequestProvider {
    public class RequestProvider : IRequestProvider {

        private readonly HttpClient _client;

        public RequestProvider() {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<TResponse> GetAsync<TRequest, TResponse>(TRequest request)
            where TRequest : class, IRequest
            where TResponse : class, IResponse =>
            await Task.Run(async () => {
                //  Check internet connection.
                if (!CrossConnectivity.Current.IsConnected) throw new ConnectivityException(AppConsts.ERROR_INTERNET_CONNECTION);

                TResponse responseToReturn = null;

                HttpResponseMessage httpResponseMessage = await _client.GetAsync(request.Url);

                if (!httpResponseMessage.IsSuccessStatusCode) {
                    throw new HttpRequestException(httpResponseMessage.ReasonPhrase);
                }

                string json = httpResponseMessage.Content.ReadAsStringAsync().Result;

                responseToReturn = await Task.Run(() => JsonConvert.DeserializeObject<TResponse>(json));

                return responseToReturn;
            });
    }
}
