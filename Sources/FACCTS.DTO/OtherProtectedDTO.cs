using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.DTO
{
    public partial class OtherProtectedDTO
    {
        [JsonProperty]
        public int Id { get; set; }
        [JsonProperty]
        public bool RelationshipToPlaintiff { get; set; }

        [JsonProperty]
        public string FirstName { get; set; }

        [JsonProperty]
        public string LastName { get; set; }

        [JsonProperty]
        public string Contact { get; set; }
    }
}
