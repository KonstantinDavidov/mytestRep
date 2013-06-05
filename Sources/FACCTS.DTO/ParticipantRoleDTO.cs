using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace FACCTS.DTO
{


    public partial class ParticipantRoleDTO
    {
        [JsonProperty]
        public int Id { get; set; }
        [JsonProperty]
        public string ParticipantRoleName { get; set; }
    }
}
