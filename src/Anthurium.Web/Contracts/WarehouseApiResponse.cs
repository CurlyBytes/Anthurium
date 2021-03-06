﻿using Anthurium.API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

using System.Threading.Tasks;

namespace Anthurium.Web.Contracts
{
    public class WarehouseApiResponse
    {
        [JsonPropertyName("@odata.count")]
        public int Count { get; set; } = 0;


        [JsonPropertyName("value")]
        public List<WarehouseReadDto> Warehouse { get; set; } = null;
    }
}
