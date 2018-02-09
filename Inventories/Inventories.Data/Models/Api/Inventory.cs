using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Inventories.Data.Models.Api
{
    public class Inventory
    {
        [JsonProperty("cinema_vista_id")]
        public string CinemaVistaId { get; set; }
        [JsonProperty("is_available")]
        public bool IsAvailable { get; set; }
        [JsonProperty("hopk")]
        public int Hopk { get; set; }
        [JsonProperty("stok_quantity")]
        public int StokQuantity { get; set; }

    }
}
