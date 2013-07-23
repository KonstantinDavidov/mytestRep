using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.DTO
{
    public partial class CourtroomDTO
    {
        [JsonProperty]
        public int Id { get; set; }

        [JsonProperty]
        public string RoomName { get; set; }

        [JsonProperty]
        public  CourtLocationDTO CourtLocation { get; set; }
    }
}
