using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.DTO
{

    public partial class AttorneyDTO
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("FirstName")]
        public string FirstName { get; set; }

        [JsonProperty("FirstName")]
        public string LastName { get; set; }

        [JsonProperty("FirstName")]
        public string FirmName { get; set; }

        [JsonProperty("StreetAddress")]
        public string StreetAddress { get; set; }

        [JsonProperty("City")]
        public string City { get; set; }

        [JsonProperty("State")]
        public string State { get; set; }

        [JsonProperty("ZipCode")]
        public string ZipCode { get; set; }

        [JsonProperty("Phone")]
        public string Phone { get; set; }

        [JsonProperty("Fax")]
        public string Fax { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("StateBarId")]
        public string StateBarId { get; set; }


    }
}
