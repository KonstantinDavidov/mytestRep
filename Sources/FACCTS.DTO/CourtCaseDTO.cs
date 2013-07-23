using FACCTS.Server.Model.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.DTO
{
    public partial class CourtCaseDTO
    {

        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("CaseNumber")]
        public string CaseNumber { get; set; }

        [JsonProperty("FirstActivity")]
        public DateTime? FirstActivity { get; set; }
        [JsonProperty("LastActivity")]
        public DateTime? LastActivity { get; set; }

        [JsonProperty("CCPORStatus")]
        public CCPORStatus? CCPORStatus { get; set; }

        [JsonProperty("CCPORId")]
        public string CCPORId { get; set; }

        [JsonProperty("RelatedCaseRecords")]
        public List<int> RelatedCaseRecords { get; set; }
        [JsonProperty("CourtOrders")]
        
        public List<int> CourtOrders { get; set; }
        [JsonProperty]
        public int? CaseStatusId { get; set; }

        [JsonProperty]
        public int? CourtClerkId { get; set; }
        [JsonProperty]
        public  int? CaseRecordId { get; set; }
    }
}
