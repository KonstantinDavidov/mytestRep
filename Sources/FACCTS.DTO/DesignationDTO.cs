using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FACCTS.DTO
{


    public partial class DesignationDTO
    {
        [JsonProperty]
        public int Id { get; set; }
        [JsonProperty]
        public string DesignationName { get; set; }
    }
}
