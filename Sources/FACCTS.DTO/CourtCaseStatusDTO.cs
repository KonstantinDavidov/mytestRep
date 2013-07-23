using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FACCTS.DTO
{

    public partial class CourtCaseStatusDTO
    {
        [JsonProperty]
        public int Id { get; set; }
        [JsonProperty]
        public string CaseStatus { get; set; }
    }
}
