using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.DTO
{
    public class CourtMemberDTO : UserDTO
    {
        [JsonProperty]
        public CourtMemberDTO Substitute { get; set; }
        [JsonProperty]
        public bool IsCertified { get; set; }

        [JsonProperty]
        public byte[] Image { get; set; }
        [JsonProperty]
        public string Phone { get; set; }
    }
}
