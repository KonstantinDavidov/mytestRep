using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FACCTS.Server.Models
{
    [JsonObject]
    public class CourtCaseCreationRequest
    {
        [JsonProperty]
        public string CaseNumber { get; set; }
    }
}