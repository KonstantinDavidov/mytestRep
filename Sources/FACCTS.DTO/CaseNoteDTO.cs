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
    public partial class CaseNoteDTO
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Author")]
        public  UserDTO Author { get; set; }

        [JsonProperty("Status")]
        public CaseNoteStatus Status { get; set; }
        
    }
}
