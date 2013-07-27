using Faccts.Model.Entities.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faccts.Model.Entities
{
    public partial class Child : IDataTransferConvertible<FACCTS.Server.Model.DataModel.Child>
    {
        public Child() : base()
        {
            this.RelationToProtected = FACCTS.Server.Model.Enums.Relationship.C;
        }

        public Child(FACCTS.Server.Model.DataModel.Child dto)
            : this()
        {
            if (dto == null)
                return;

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
            this.RelationToProtected = dto.RelationshipToProtected;
            this.MarkAsUnchanged();
        }

        FACCTS.Server.Model.DataModel.Child IDataTransferConvertible<FACCTS.Server.Model.DataModel.Child>.ToDTO()
        {
            if (!this.IsDirty)
                return null;
            return new FACCTS.Server.Model.DataModel.Child()
            {
                Id = this.Id,
                EntityType = this.EntityType,
                FirstName = this.FirstName,
                LastName = this.LastName,
                RelationshipToProtected = this.RelationToProtected,
                Sex = this.Sex,
                DateOfBirth = this.DateOfBirth.GetValueOrDefault(),
                State = (FACCTS.Server.Model.DataModel.ObjectState)(int)this.ChangeTracker.State,
            };
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


    }
}
