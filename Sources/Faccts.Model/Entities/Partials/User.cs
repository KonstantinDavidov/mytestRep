using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Faccts.Model.Entities
{
    public partial class User : INavigationPropertiesLoadable
    {
        public User(FACCTS.Server.Model.DataModel.User dtoUser) : this()
        {
            this.Id = dtoUser.Id;
            this.Username = dtoUser.Username;
            this.Email = dtoUser.Email;
            this.Password = dtoUser.Password;
            this.FirstName = dtoUser.FirstName;
            this.MiddleName = dtoUser.MiddleName;
            this.LastName = dtoUser.LastName;
            this.Comment = dtoUser.Comment;

            this.IsApproved = dtoUser.IsApproved;
            this.PasswordFailuresSinceLastSuccess = dtoUser.PasswordFailuresSinceLastSuccess;
            this.LastPasswordFailureDate = dtoUser.LastPasswordFailureDate;
            this.LastActivityDate = dtoUser.LastActivityDate;
            this.LastLockoutDate = dtoUser.LastLockoutDate;
            this.LastLoginDate = dtoUser.LastLoginDate;
            this.ConfirmationToken = dtoUser.ConfirmationToken;
            this.CreateDate = dtoUser.CreateDate;
            this.IsLockedOut = dtoUser.IsLockedOut;
            this.LastPasswordChangedDate = dtoUser.LastPasswordChangedDate;
            this.PasswordVerificationToken = dtoUser.PasswordVerificationToken;
            this.PasswordVerificationTokenExpirationDate = dtoUser.PasswordVerificationTokenExpirationDate;

        }
    }
       
}
