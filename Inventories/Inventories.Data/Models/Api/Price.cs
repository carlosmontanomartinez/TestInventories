using System;
using Newtonsoft.Json;

namespace Inventories.Data.Models.Api
{
    public class Price
    {
        [JsonProperty("cinema_vista_id")]
        public string CinemaVistaId { get; set; }
        [JsonProperty("normal_price")]
        public int NormalPrice { get; set; }
        [JsonProperty("promotion_price")]
        public int PromotionalPrice { get; set; }
        [JsonProperty("hopk")]
        public int Hopk { get; set; }
        [JsonProperty("item_id")]
        public int ItemId { get; set; }
    }
}
