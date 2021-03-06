using Anthurium.API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Anthurium.Web.Contracts
{
    public class ItemApiResponse
    {
        [JsonPropertyName("@odata.count")]
        public int Count { get; set; }

        [JsonPropertyName("value")]
        public List<ItemReadDto> Item { get; set; }
    }
}
