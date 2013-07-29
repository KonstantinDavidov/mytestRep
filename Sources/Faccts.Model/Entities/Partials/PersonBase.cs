using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using Faccts.Model.Entities.Validation;

namespace Faccts.Model.Entities
{
    public partial class PersonBase : IDataTransferConvertible<FACCTS.Server.Model.DataModel.Witness>, IValidatableObject
    {
        partial void Initialize()
        {
            this.WhenAny(x => x.PartyFor, x => x.Value)
                .Subscribe(_ =>
                {
                    this.OnPropertyChanged("PartyToName");
                }
                );
        }

        public PersonBase(FACCTS.Server.Model.DataModel.Witness dto) : this()
        {
            if (dto == null)
                return;

            this.Id = dto.Id;
            this.PartyFor = dto.WitnessFor;
            this.EntityType = dto.EntityType;
            this.FirstName = dto.FirstName;
            this.LastName = dto.LastName;
            this.Sex = dto.Sex;
            this.DateOfBirth = dto.DateOfBirth;
            this.Contact = dto.Contact;
            this.Age = dto.Age;
            this.AddressInfo = new AddressInfo(dto.AddressInfo);
            this.Email = dto.Email;
            this.PersonType = FACCTS.Server.Model.Enums.PersonType.Witness;
            //this.Appearances = 
            this.MarkAsUnchanged();
        }

        public string PartyToName
        {
            get
            {
                string result = null;
                switch(this.PartyFor)
                {
                    case FACCTS.Server.Model.Enums.PartyFor.Party1:
                        result = !string.IsNullOrWhiteSpace(CourtCase.Party1.FullName) ? CourtCase.Party1.FullName : FACCTS.Server.Model.Enums.PartyFor.Party1.ToString();
                        break;
                    case FACCTS.Server.Model.Enums.PartyFor.Party2:
                        result = !string.IsNullOrWhiteSpace(CourtCase.Party2.FullName) ? CourtCase.Party2.FullName : FACCTS.Server.Model.Enums.PartyFor.Party2.ToString();
                        break;
                }

                return result;
            }
        }

        FACCTS.Server.Model.DataModel.Witness IDataTransferConvertible<FACCTS.Server.Model.DataModel.Witness>.ToDTO()
        {
            if (!this.IsDirty)
                return null;
            return new FACCTS.Server.Model.DataModel.Witness()
            {
                Id = this.Id,
                EntityType = this.EntityType,
                WitnessFor = this.PartyFor,
                FirstName = this.FirstName,
                LastName = this.LastName,
                Contact = this.Contact,
                State = (FACCTS.Server.Model.DataModel.ObjectState)(int)this.ChangeTracker.State,
            };
        }


        private Dictionary<string, string> _errors = new Dictionary<string, string>();
        public virtual IList<string> Errors
        {
            get { return _errors.Values.ToList().AsReadOnly(); }
        }

        public virtual bool IsValid
        {
            get { return !Errors.Any(); }
        }

        public virtual string Error
        {
            get { return Errors.FirstOrDefault(); }
        }

        public virtual string this[string propertyName]
        {
            get 
            {
                propertyName = propertyName ?? string.Empty;
                return this.ValidateByPropertyName(_requierdFields, _errors, propertyName);
            }
        }

        private static Dictionary<string, string> _requierdFields = new Dictionary<string, string>()
        {
            {"EntityType", "Entity Type"},
            {"FirstName", "First Name"},
            {"LastName", "Last Name"}
        };
    }
}
