using Newtonsoft.Json;
using Plugin.Connectivity;
using Polly;
using Polly.CircuitBreaker;
using Polly.Wrap;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TOua.Exceptions;
using TOua.Helpers;

namespace TOua.Services.RequestProvider {
    public class ResilientRequestProvider : IResilientRequestProvider {

        private readonly HttpClient _client;

        private PolicyWrap _policyWrap;

        public ResilientRequestProvider() {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            InitializePolly();
        }

        public async Task<TResult> GetAsync<TResult>(string uri) {
            //  Check internet connection.
            if (!CrossConnectivity.Current.IsConnected) throw new ConnectivityException(AppConsts.ERROR_INTERNET_CONNECTION);

            string serialized = null;
            var httpResponse = await HttpInvoker(async () => {
                var response = await _client.GetAsync(uri);
                response.EnsureSuccessStatusCode();
                serialized = await response.Content.ReadAsStringAsync();
                return response;
            });
            return JsonConvert.DeserializeObject<TResult>(serialized);
        }

        private async Task<HttpResponseMessage> HttpInvoker(Func<Task<HttpResponseMessage>> operation) => await _policyWrap.ExecuteAsync(operation);

        private void InitializePolly() {
            var retryPolicy = Policy
                 // Don't retry if circuit breaker has broken the circuit
                 .Handle<Exception>(e => !(e is BrokenCircuitException))
                 .WaitAndRetryAsync(3,
                                    retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                                    (exception, delay, retryCount, context) => {
                                        Debug.WriteLine($"Retry {retryCount} after {delay.Seconds} seconds delay due to {exception.Message}");
                                    });

            var circuitBreakerPolicy = Policy
                .Handle<Exception>()
                .CircuitBreakerAsync(4,
                                     TimeSpan.FromSeconds(5),
                                     // onBreak
                                     (exception, delay) => Debug.WriteLine($"Breaking the circuit for {delay.Seconds} seconds due to {exception.Message}"),
                                     // onReset
                                     () => Debug.WriteLine($"Call ok - closing the circuit again."),
                                     // onHalfOpen
                                     () => Debug.WriteLine($"Circuit is half-open. The next call is a trial."));

            _policyWrap = Policy.WrapAsync(retryPolicy, circuitBreakerPolicy);
        }
    }
}
