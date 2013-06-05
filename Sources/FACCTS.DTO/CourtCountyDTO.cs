using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.DTO
{
    public partial class CourtCountyDTO
    {
        [JsonProperty]
        public int Id { get; set; }

        [JsonProperty]
        public string CourtCode { get; set; }

        [JsonProperty]
        public string County { get; set; }

        [JsonProperty]
        public string CourtName { get; set; }

        [JsonProperty]
        public string Location { get; set; }

        [JsonProperty]
        public  List<CourtLocationDTO> CourtLocations { get; set; }
    }
}
