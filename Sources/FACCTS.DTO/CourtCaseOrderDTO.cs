using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FACCTS.DTO
{
    public partial class CourtCaseOrderDTO
    {

        [JsonProperty]
        public int Id { get; set; }
        [JsonProperty]
        public int CourtCaseId { get; set; }
        [JsonProperty]
        
        public CourtCaseDTO CourtCase { get; set; }
        [JsonProperty]
        public int AvailableCourtOrderId { get; set; }
        [JsonProperty]
        
        public AvailableCourtOrderDTO AvailableCourtOrder { get; set; }

        [JsonProperty]
        public string XMLContent { get; set; }

        [JsonProperty]
        public bool IsSigned { get; set; }

        [JsonProperty]
        public string ServerFileName { get; set; }
    }

    
}
