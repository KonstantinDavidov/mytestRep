using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FACCTS.DTO
{
    public partial class HairColorDTO
    {
        [JsonProperty]
        public int Id { get; set; }
        [JsonProperty]
        public string Color { get; set; }
    }
}
