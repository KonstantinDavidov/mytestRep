using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace FACCTS.DTO
{


    public partial class SexDTO
    {
        [JsonProperty]
        public int Id { get; set; }
        [JsonProperty]
        public string SexName { get; set; }
    }
}
