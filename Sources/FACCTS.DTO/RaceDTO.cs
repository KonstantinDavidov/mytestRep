
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FACCTS.DTO
{
    public partial class RaceDTO
    {
        [JsonProperty]
        public int Id { get; set; }
        [JsonProperty]
        public string RaceName { get; set; }
    }
}
