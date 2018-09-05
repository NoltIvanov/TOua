using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TOua.Models.Rests.Requests;
using TOua.Models.Rests.Responses;
using TOua.Services.RequestProvider;

namespace TOua.Services.CarsInfo {
    public class CarsInfoService : ICarsInfoService {

        private readonly IRequestProvider _requestProvider;

        public CarsInfoService(IRequestProvider requestProvider) {
            _requestProvider = requestProvider;
        }

        public Task GetCarsInfoByCarIdAsync(string carId, CancellationTokenSource cancellationTokenSource) =>
            Task.Run(async () => {
                GetCarsInfoByCarIdRequest getCarsInfoByCarIdRequest = new GetCarsInfoByCarIdRequest() {
                    Url = string.Format("http://localhost:13823/api/carid/getinfobycarnumber?carNumber={0}", carId)
                };

                try {
                    await _requestProvider.GetAsync<GetCarsInfoByCarIdRequest, GetCarsInfoByCarIdResponse>(getCarsInfoByCarIdRequest);
                }
                catch (Exception exc) {

                    throw;
                }

            }, cancellationTokenSource.Token);
    }
}
