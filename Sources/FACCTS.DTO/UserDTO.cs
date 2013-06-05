using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace FACCTS.DTO
{
    public partial class UserDTO
    {
        [JsonProperty]
        public int UserId { get; set; }

        [JsonProperty]
        public String Username { get; set; }
        [JsonProperty]
        public String Email { get; set; }

        [JsonProperty]
        public String Password { get; set; }
        [JsonProperty]
        public String FirstName { get; set; }
        [JsonProperty]
        public String LastName { get; set; }
        [JsonProperty]
        public String MiddleName { get; set; }

        [JsonProperty]
        public String Comment { get; set; }
        [JsonProperty]
        public Boolean IsApproved { get; set; }
        [JsonProperty]
        public int PasswordFailuresSinceLastSuccess { get; set; }
        [JsonProperty]
        public DateTime? LastPasswordFailureDate { get; set; }
        [JsonProperty]
        public DateTime? LastActivityDate { get; set; }
        [JsonProperty]
        public DateTime? LastLockoutDate { get; set; }
        [JsonProperty]
        public DateTime? LastLoginDate { get; set; }
        [JsonProperty]
        public String ConfirmationToken { get; set; }
        [JsonProperty]
        public DateTime? CreateDate { get; set; }
        [JsonProperty]
        public Boolean IsLockedOut { get; set; }
        [JsonProperty]
        public DateTime? LastPasswordChangedDate { get; set; }
        [JsonProperty]
        public String PasswordVerificationToken { get; set; }
        [JsonProperty]
        public DateTime? PasswordVerificationTokenExpirationDate { get; set; }
    }
}