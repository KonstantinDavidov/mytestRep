using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.DTO
{
    public partial class ChildDTO
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("FirstName")]
        public string FirstName { get; set; }

        [JsonProperty("LastName")]
        public string LastName { get; set; }

        [JsonProperty("RelationshipToProtected")]
        public bool RelationshipToProtected { get; set; }

        [JsonProperty("Sex")]
        
        public  SexDTO Sex { get; set; }
        [JsonProperty("DateOfBirth")]
        public DateTime DateOfBirth { get; set; }
    }
}
