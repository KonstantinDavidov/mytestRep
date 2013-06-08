using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using CsvHelper.TypeConversion;
using System.ComponentModel.DataAnnotations.Schema;
namespace FACCTS.Server.Model.DataModel
{
    [Table("User")]
    public partial class User
    {
        [Key]
        [Column("Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        public String Username { get; set; }

        public String Email { get; set; }

        [Required, DataType(DataType.Password)]
        public String Password { get; set; }

        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String MiddleName { get; set; }

        [DataType(DataType.MultilineText)]
        public String Comment { get; set; }

        public Boolean IsApproved { get; set; }
        public int PasswordFailuresSinceLastSuccess { get; set; }
        public DateTime? LastPasswordFailureDate { get; set; }
        public DateTime? LastActivityDate { get; set; }
        public DateTime? LastLockoutDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public String ConfirmationToken { get; set; }
        public DateTime? CreateDate { get; set; }
        public Boolean IsLockedOut { get; set; }
        public DateTime? LastPasswordChangedDate { get; set; }
        public String PasswordVerificationToken { get; set; }
        public DateTime? PasswordVerificationTokenExpirationDate { get; set; }

        public virtual ICollection<Role> Roles { get; set; }

        public override bool Equals(object obj)
        {
            // Check for null values and compare run-time types.
            if (obj == null || GetType() != obj.GetType())
                return false;

            User u = (User)obj;
            if (u.UserId != this.UserId)
                return false;
            //if (u.Username != this.Username)
            //    return false;
            //if (u.Email != this.Email)
            //    return false;
            //if (u.Password != this.Password)
            //    return false;

            return true;

        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ this.UserId;
        }
    }
}