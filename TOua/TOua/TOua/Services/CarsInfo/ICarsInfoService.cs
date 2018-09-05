using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TOua.Services.CarsInfo {
    public interface ICarsInfoService {

        Task GetCarsInfoByCarIdAsync(string carId, CancellationTokenSource cancellationTokenSource);
    }
}
