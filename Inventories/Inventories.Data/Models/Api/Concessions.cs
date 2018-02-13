using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Inventories.Data.Models.Api
{
    public class Concession
    {
        [JsonProperty("hopk")]
        public int Hopk { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("alt_sale_type")]
        public bool AltSaleType { get; set; }
        [JsonProperty("hopks_alters")]
        public List<string> HopksAlters { get; set; }
        [JsonProperty("boms")]
        public List<string> Boms { get; set; }
    }
}
