using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.DTO
{
    public partial class InterpreterDTO
    {
        [JsonProperty]
        public int Id { get; set; }

        [JsonProperty]
        public  CourtPartyDTO InterpreterFor { get; set; }

        [JsonProperty]
        public string FirstName { get; set; }

        [JsonProperty]
        public string LastName { get; set; }

        [JsonProperty]
        public string Contact { get; set; }
        
    }
}
