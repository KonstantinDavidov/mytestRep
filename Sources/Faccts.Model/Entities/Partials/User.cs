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
        partial void Initialize()
        {
            this.MarkAsUnchanged();
            this.ChangeTracker.ChangeTrackingEnabled = false;
        }

        public User(FACCTS.Server.Model.DataModel.User dto) : this()
        {
            if (dto != null)
            {
                this.Id = dto.Id;
                this.Username = dto.Username;
                this.Email = dto.Email;
                this.Password = dto.Password;
                this.FirstName = dto.FirstName;
                this.MiddleName = dto.MiddleName;
                this.LastName = dto.LastName;
                this.Comment = dto.Comment;

                this.IsApproved = dto.IsApproved;
                this.PasswordFailuresSinceLastSuccess = dto.PasswordFailuresSinceLastSuccess;
                this.LastPasswordFailureDate = dto.LastPasswordFailureDate;
                this.LastActivityDate = dto.LastActivityDate;
                this.LastLockoutDate = dto.LastLockoutDate;
                this.LastLoginDate = dto.LastLoginDate;
                this.ConfirmationToken = dto.ConfirmationToken;
                this.CreateDate = dto.CreateDate;
                this.IsLockedOut = dto.IsLockedOut;
                this.LastPasswordChangedDate = dto.LastPasswordChangedDate;
                this.PasswordVerificationToken = dto.PasswordVerificationToken;
                this.PasswordVerificationTokenExpirationDate = dto.PasswordVerificationTokenExpirationDate;

                this.MarkAsUnchanged();
            }

            
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
                Roles = this.Role.Where(r => r.IsDirty).Select(x => x.ConvertToDTO()).ToArray(),
                State = (FACCTS.Server.Model.DataModel.ObjectState)(int)this.ChangeTracker.State,
            };
        }

    }
       
}
