using FACCTS.Server.Model.Enums;
using Newtonsoft.Json;
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

        [JsonProperty("CaseStatus")]
        public  CourtCaseStatusDTO CaseStatus { get; set; }
        [JsonProperty("FirstActivity")]
        public DateTime? FirstActivity { get; set; }
        [JsonProperty("LastActivity")]
        public DateTime? LastActivity { get; set; }
        [JsonProperty("CourtClerk")]
        public  UserDTO CourtClerk { get; set; }

        [JsonProperty("CCPORStatus")]
        public CCPORStatus? CCPORStatus { get; set; }

        [JsonProperty("CCPORId")]
        public string CCPORId { get; set; }

        [JsonProperty("CaseRecord")]
        public  CaseRecordDTO CaseRecord { get; set; }

        [JsonProperty("RelatedCaseRecords")]
        public List<CaseRecordDTO> RelatedCaseRecords { get; set; }
        [JsonProperty("CourtOrders")]
        public List<CourtCaseOrderDTO> CourtOrders { get; set; }
    }
}
