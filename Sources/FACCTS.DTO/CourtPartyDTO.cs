using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.DTO
{
    public partial class CourtPartyDTO
    {
        [JsonProperty]
        public int Id { get; set; }

        [JsonProperty]
        public string FirstName { get; set; }

        [JsonProperty]
        public string MiddleName { get; set; }

        [JsonProperty]
        public string LastName { get; set; }

        [JsonProperty]
        public  DesignationDTO Designation { get; set; }

        [JsonProperty]
        public string Description { get; set; }

        [JsonProperty]
        public  ParticipantRoleDTO ParticipantRole { get; set; }

        [JsonProperty]
        public string Address { get; set; }

        [JsonProperty]
        public string City { get; set; }

        [JsonProperty]
        public string State { get; set; }

        [JsonProperty]
        public string ZipCode { get; set; }

        [JsonProperty]
        public string Phone { get; set; }

        [JsonProperty]
        public string Fax { get; set; }

        [JsonProperty]
        public  SexDTO Sex { get; set; }
        [JsonProperty]
        public  HairColorDTO HairColor { get; set; }
        [JsonProperty]
        public  EyesColorDTO EyesColor { get; set; }
        [JsonProperty]
        public  RaceDTO Race { get; set; }
        [JsonProperty]
        public decimal Weight { get; set; }
        [JsonProperty]
        public decimal HeightFt { get; set; }
        [JsonProperty]
        public decimal HeightIns { get; set; }

        [JsonProperty]
        public DateTime DateOfBirth { get; set; }
        [JsonProperty]
        public int Age { get; set; }
    }
}
