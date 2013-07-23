using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.DTO
{

    public partial class AppearanceDTO
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Date")]
        public DateTime Date { get; set; }

        [JsonProperty("FirstName")]
        public string FirstName { get; set; }

        [JsonProperty("LastName")]
        public string LastName { get; set; }

        [JsonProperty("Appear")]
        public bool? Appear { get; set; }

        [JsonProperty("Sworn")]
        public bool? Sworn { get; set; }

        [JsonProperty("AttorneyPresent")]
        public bool? AttorneyPresent { get; set; }

        //[JsonProperty("CaseRecord")]
        //public  CaseRecordDTO CaseRecord { get; set; }

        [JsonProperty]
        public int? DesignationID { get; set; }
    }
}
