using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.DTO
{
    public partial class RelatedCaseDTO
    {
        [JsonProperty]
        public int CaseRecordId { get; set; }
        [JsonProperty]
        public int CourtCaseId { get; set; }
        [JsonProperty]
        public  CourtCaseDTO CourtCase { get; set; }
    }

}
