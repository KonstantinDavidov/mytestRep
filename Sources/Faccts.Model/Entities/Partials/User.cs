﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace Faccts.Model.Entities
{
    public partial class User : INavigationPropertiesLoadable, IDataTransferConvertible<FACCTS.Server.Model.DataModel.User>
    {
        partial void Initialize()
        {
            this.MarkAsUnchanged();
            this.ChangeTracker.ChangeTrackingEnabled = false;
            this.WhenAny(
                x => x.FirstName,
                x => x.MiddleName,
                x => x.LastName,
                (x1, x2, x3) => string.Empty
                )
                .Subscribe(_ =>
                {
                    this.OnPropertyChanged("FullName", false);
                }
                );
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

        public string FullName
        {
            get
            {
                return string.Format("{0} {1} {1}", this.FirstName, this.MiddleName, this.LastName);
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

        public override int GetHashCode()
        {
            return
                Id.GetHashCode() ^
                Username.ThisOrEmpty().GetHashCode() ^
                Email.ThisOrEmpty().GetHashCode() ^
                Password.ThisOrEmpty().GetHashCode() ^
                FirstName.ThisOrEmpty().GetHashCode() ^
                LastName.ThisOrEmpty().GetHashCode() ^
                MiddleName.ThisOrEmpty().GetHashCode() ^
                Comment.ThisOrEmpty().GetHashCode() ^
                IsApproved.GetHashCode() ^
                PasswordFailuresSinceLastSuccess.GetHashCode() ^
                LastPasswordFailureDate.GetValueOrDefault().GetHashCode() ^
                LastActivityDate.GetValueOrDefault().GetHashCode() ^
                LastLockoutDate.GetValueOrDefault().GetHashCode() ^
                LastLoginDate.GetValueOrDefault().GetHashCode() ^
                ConfirmationToken.ThisOrEmpty().GetHashCode() ^
                CreateDate.GetValueOrDefault().GetHashCode() ^
                IsLockedOut.GetHashCode() ^
                LastPasswordChangedDate.GetValueOrDefault().GetHashCode() ^
                PasswordVerificationToken.ThisOrEmpty().GetHashCode() ^
                PasswordVerificationTokenExpirationDate.GetValueOrDefault().GetHashCode();


        }

        public override bool Equals(object obj)
        {
            // Check for null
            if (obj == null) return false;

            // Check for type
            if (this.GetType() != obj.GetType()) return false;

            // Cast as Employee
            User user = (User)obj;

            return (this == user);
        }

        public static bool operator ==(User left, User right)
        {
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(left, right))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)left == null) || ((object)right == null))
            {
                return false;
            }

            if (left.Id != right.Id)
                return false;
            if (left.Username != right.Username)
                return false;
            if (left.Email != right.Email)
                return false;
            if (left.FirstName != right.FirstName)
                return false;
            if (left.LastName != right.LastName)
                return false;
            if (left.MiddleName != right.MiddleName)
                return false;
            if (left.Comment != right.Comment)
                return false;
            if (left.IsApproved != right.IsApproved)
                return false;
            if (left.CreateDate != right.CreateDate)
                return false;
            if (left.IsLockedOut != right.IsLockedOut)
                return false;

            return true;
        }

        public static bool operator !=(User left, User right)
        {
            return !(left == right);
        }

    }
       
}
