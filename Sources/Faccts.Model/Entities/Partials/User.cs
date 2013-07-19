using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Faccts.Model.Entities
{
    public partial class User : INavigationPropertiesLoadable, IDataTransferConvertible<FACCTS.Server.Model.DataModel.User>
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

        public FACCTS.Server.Model.DataModel.User ToDTO()
        {
            if (!this.IsDirty)
                return null;
            return new FACCTS.Server.Model.DataModel.User()
            {
                Id = this.Id,
                Username = this.Username,
                Email = this.Email,
                Password = this.Password,
                FirstName = this.FirstName,
                LastName = this.LastName,
                MiddleName = this.MiddleName,
                Comment = this.Comment,
                IsApproved = this.IsApproved,
                PasswordFailuresSinceLastSuccess = this.PasswordFailuresSinceLastSuccess,
                LastPasswordFailureDate = this.LastPasswordFailureDate,
                LastActivityDate = this.LastActivityDate,
                LastLockoutDate = this.LastLockoutDate,
                LastLoginDate = this.LastLoginDate,
                ConfirmationToken = this.ConfirmationToken,
                CreateDate = this.CreateDate,
                IsLockedOut = this.IsLockedOut,
                LastPasswordChangedDate = this.LastPasswordChangedDate,
                PasswordVerificationToken = this.PasswordVerificationToken,
                PasswordVerificationTokenExpirationDate = this.PasswordVerificationTokenExpirationDate,
                Roles = this.Role.Where(r => r.IsDirty).Select(x => x.ToDTO()).ToArray(),
                State = (FACCTS.Server.Model.DataModel.ObjectState)(int)this.ChangeTracker.State,
            };
        }
    }
       
}
