using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.DTO
{
    public partial class CaseRecordDTO
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Party1")]
        public CourtPartyDTO Party1 { get; set; }

        [JsonProperty("Party2")]
        public CourtPartyDTO Party2 { get; set; }

        [JsonProperty("Children")]
        public List<ChildDTO> Children { get; set; }

        [JsonProperty("OtherProtected")]
        public List<OtherProtectedDTO> OtherProtected { get; set; }

        [JsonProperty("AttorneyForParty1")]
        public AttorneyDTO AttorneyForParty1 { get; set; }

        //public bool Party1ProPer { get; set; }
        [JsonProperty("AttorneyForParty2")]
        public  AttorneyDTO AttorneyForParty2 { get; set; }
        [JsonProperty("AttorneyForChild")]
        public  AttorneyDTO AttorneyForChild { get; set; }

        [JsonProperty("Witnesses")]
        public  List<WitnessDTO> Witnesses { get; set; }

        [JsonProperty("Interpreters")]
        public  List<InterpreterDTO> Interpreters { get; set; }

        [JsonProperty("Appearances")]
        public  List<AppearanceDTO> Appearances { get; set; }

        [JsonProperty("CaseHistory")]
        public  List<CaseHistoryDTO> CaseHistory { get; set; }

        [JsonProperty("CaseNotes")]
        public  List<CaseNoteDTO> CaseNotes { get; set; }

        [JsonProperty("RelatedCases")]
        public List<RelatedCaseDTO> RelatedCases { get; set; }

        [JsonProperty("Judge")]
        public string Judge { get; set; }
    }
}
