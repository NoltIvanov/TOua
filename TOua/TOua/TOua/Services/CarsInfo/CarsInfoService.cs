using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TOua.Exceptions;
using TOua.Helpers;
using TOua.Models.DTOs;
using TOua.Models.Rests.Requests;
using TOua.Models.Rests.Responses;
using TOua.Services.RequestProvider;

namespace TOua.Services.CarsInfo {
    public class CarsInfoService : ICarsInfoService {

        private readonly IRequestProvider _requestProvider;

        public CarsInfoService(IRequestProvider requestProvider) {
            _requestProvider = requestProvider;
        }

        public Task<List<CarinfoDTO>> GetCarsInfoByCarIdAsync(string carId, CancellationTokenSource cancellationTokenSource) =>
            Task.Run<List<CarinfoDTO>>(async () => {
                GetCarsInfoByCarIdRequest getCarsInfoByCarIdRequest = new GetCarsInfoByCarIdRequest() {
                    Url = string.Format("http://31.128.79.4:13823/api/carid/getinfobycarnumber?carNumber={0}", carId)
                };

                List<CarinfoDTO> foundCars = new List<CarinfoDTO>();

                GetCarsInfoByCarIdResponse getCarsInfoByCarIdResponse;

                try {
                    getCarsInfoByCarIdResponse = await _requestProvider.GetAsync<GetCarsInfoByCarIdRequest, GetCarsInfoByCarIdResponse>(getCarsInfoByCarIdRequest);

                    foundCars = getCarsInfoByCarIdResponse.ToList();
                } catch (ConnectivityException exc) {
                    throw exc;
                } catch (Exception exc) {
                    throw new Exception(exc.Message);
                }

                return foundCars;
            }, cancellationTokenSource.Token);
    }
}
