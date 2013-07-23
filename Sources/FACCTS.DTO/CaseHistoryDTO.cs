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
    public partial class CaseHistoryDTO
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Date")]
        public DateTime Date { get; set; }

        [JsonProperty("CourtRoom")]
        
        public CourtroomDTO CourtRoom { get; set; }

        [JsonProperty("Orders")]
        public string Orders { get; set; }//TODO: modify this when Order entity implemented
        
        
    }
}
