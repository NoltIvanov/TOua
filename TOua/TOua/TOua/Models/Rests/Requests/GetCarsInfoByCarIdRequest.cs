using System;
using System.Collections.Generic;
using System.Text;

namespace TOua.Models.Rests.Requests {
    public class GetCarsInfoByCarIdRequest : IRequest {

        public string Url { get; set; }
    }
}
