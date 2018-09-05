using System;
using System.Collections.Generic;
using System.Text;
using TOua.Services.RequestProvider;

namespace TOua.Services.CarsInfo {
    public class CarsInfoService : ICarsInfoService {

        private readonly IRequestProvider _requestProvider;

        public CarsInfoService(IRequestProvider requestProvider) {
            _requestProvider = requestProvider;
        }
    }
}
