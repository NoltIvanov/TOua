using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TOua.Models.DTOs;

namespace TOua.Services.CarsInfo {
    public interface ICarsInfoService {

        Task<List<CarinfoDTO>> GetCarsInfoByCarIdAsync(string carId, CancellationTokenSource cancellationTokenSource);
    }
}
