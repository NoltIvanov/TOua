using Newtonsoft.Json;

namespace TOua.Models.DTOs {
    public class CarinfoDTO {
        [JsonProperty("person")]
        public string Person { get; set; }

        [JsonProperty("reg_addr_koatuu")]
        public string RegAddrKoatuu { get; set; }

        [JsonProperty("oper_code")]
        public string OperCode { get; set; }

        [JsonProperty("oper_name")]
        public string OperName { get; set; }

        [JsonProperty("d_reg")]
        public string DReg { get; set; }

        [JsonProperty("dep_code")]
        public string DepCode { get; set; }

        [JsonProperty("dep")]
        public string Dep { get; set; }

        [JsonProperty("brand")]
        public string Brand { get; set; }

        [JsonProperty("model")]
        public string ModelName { get; set; }

        [JsonProperty("make_year")]
        public string MakeYear { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("purpose")]
        public string Purpose { get; set; }

        [JsonProperty("fuel")]
        public string Fuel { get; set; }

        [JsonProperty("capacity")]
        public string Capacity { get; set; }

        [JsonProperty("own_weight")]
        public string OwnWeight { get; set; }

        [JsonProperty("total_weight")]
        public string TotalWeight { get; set; }

        [JsonProperty("n_reg_new")]
        public string NRegNew { get; set; }
    }
}
