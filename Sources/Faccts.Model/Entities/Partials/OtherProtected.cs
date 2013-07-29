using Faccts.Model.Entities.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faccts.Model.Entities
{
    public partial class OtherProtected : IDataTransferConvertible<FACCTS.Server.Model.DataModel.OtherProtected>
    {

        public OtherProtected()
        {

        }

        public OtherProtected(FACCTS.Server.Model.DataModel.OtherProtected dto)
            : this()
        {
            if (dto == null)
                return;

            this.PersonType = FACCTS.Server.Model.Enums.PersonType.OtherProtected;
            Id = dto.Id;
            FirstName = dto.FirstName;
            LastName = dto.LastName;
            EntityType = dto.EntityType;
            Sex = dto.Sex;
            DateOfBirth = dto.DateOfBirth;
            Contact = dto.Contact;
            Age = dto.Age;
            AddressInfo = new AddressInfo(dto.AddressInfo);
            Email = dto.Email;
            //Appearances = 
            RelationToProtected = dto.RelationshipToPlaintiff;
            IsHouseHold = dto.IsHouseHold;

            this.MarkAsUnchanged();
        }

        public override string this[string propertyName]
        {
            get
            {
                propertyName = propertyName ?? string.Empty;
                return this.ValidateByPropertyName(_requierdFields, _errors, propertyName);
            }
        }

        private Dictionary<string, string> _errors = new Dictionary<string, string>();
        public override IList<string> Errors
        {
            get
            {
                return _errors.Values.ToList().AsReadOnly();
            }
        }

        private static Dictionary<string, string> _requierdFields = new Dictionary<string, string>()
        {
            {"EntityType", "Entity Type"},
            {"FirstName", "First Name"},
            {"LastName", "Last Name"},
            {"Sex", "Sex"},
            {"RelationshipToProtected", "Relationship To Protected"},
            {"DateOfBirth", "Date Of Birth"},
        };

        FACCTS.Server.Model.DataModel.OtherProtected IDataTransferConvertible<FACCTS.Server.Model.DataModel.OtherProtected>.ToDTO()
        {
            if (!this.IsDirty)
                return null;

            return new FACCTS.Server.Model.DataModel.OtherProtected()
            {
                Id = this.Id,
                EntityType = this.EntityType,
                FirstName = this.FirstName,
                LastName = this.LastName,
                RelationshipToPlaintiff = this.RelationToProtected,
                Sex = this.Sex,
                DateOfBirth = this.DateOfBirth.GetValueOrDefault(),
                State = (FACCTS.Server.Model.DataModel.ObjectState)(int)this.ChangeTracker.State,
                IsHouseHold = this.IsHouseHold,
            };
        }
    }
}
