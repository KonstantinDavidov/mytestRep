using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.DTO
{
    public partial class CourtLocationDTO
    {
        [JsonProperty]
        public int Id { get; set; }

        [JsonProperty]
        public string Name { get; set; }
        [JsonProperty]
        public string Description { get; set; }

        [JsonProperty]
        public string StreetAddress { get; set; }

        [JsonProperty]
        public string State { get; set; }

        [JsonProperty]
        public string PostalCode { get; set; }

        [JsonProperty]
        public  CourtCountyDTO CourtCounty { get; set; }

        [JsonProperty]
        public  List<CourtroomDTO> Courtrooms { get; set; }
    }
}
