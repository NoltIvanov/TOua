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

        private readonly IResilientRequestProvider _resilientRequestProvider;

        public CarsInfoService(IRequestProvider requestProvider, IResilientRequestProvider resilientRequestProvider) {
            _requestProvider = requestProvider;
            _resilientRequestProvider = resilientRequestProvider;
        }

        public Task<List<CarinfoDTO>> GetCarsInfoByCarIdAsync(string carId, CancellationTokenSource cancellationTokenSource) =>
            Task.Run<List<CarinfoDTO>>(async () => {
                List<CarinfoDTO> foundCars = null;

                //try {
                //    string url = string.Format("http://31.128.79.4:13823/api/carid/getinfobycarnumber?carNumber={0}", carId);

                //    foundCars = await _resilientRequestProvider.GetAsync<List<CarinfoDTO>>(url);
                //} catch (ConnectivityException exc) {
                //    throw exc;
                //} catch (Exception ex) {
                //    Debug.WriteLine($"ERROR: {ex.Message}");
                //    throw new Exception(ex.Message);
                //}

                GetCarsInfoByCarIdRequest getCarsInfoByCarIdRequest = new GetCarsInfoByCarIdRequest() {
                    Url = string.Format("http://31.128.79.4:13823/api/carid/getinfobycarnumber?carNumber={0}", carId)
                };

                GetCarsInfoByCarIdResponse getCarsInfoByCarIdResponse;

                try {
                    getCarsInfoByCarIdResponse = await _requestProvider.GetAsync<GetCarsInfoByCarIdRequest, GetCarsInfoByCarIdResponse>(getCarsInfoByCarIdRequest);

                    foundCars = getCarsInfoByCarIdResponse.ToList();
                }
                catch (ConnectivityException exc) {
                    throw exc;
                }
                catch (Exception exc) {
                    throw new Exception(exc.Message);
                }

                return foundCars;
            }, cancellationTokenSource.Token);
    }
}
