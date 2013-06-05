using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.DTO
{

    public partial class AvailableCourtOrderDTO
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("FileName")]
        public string FileName { get; set; }

        [JsonProperty("Code")]
        public string Code { get; set; }
       
    }
}
