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

        public string PartyToName
        {
            get
            {
                string result = null;
                switch(this.PartyFor)
                {
                    case Entities.PartyFor.Party1:
                        result = !string.IsNullOrWhiteSpace(CourtCase.Party1.FullName) ? CourtCase.Party1.FullName : Entities.PartyFor.Party1.ToString();
                        break;
                    case Entities.PartyFor.Party2:
                        result = !string.IsNullOrWhiteSpace(CourtCase.Party2.FullName) ? CourtCase.Party2.FullName : Entities.PartyFor.Party2.ToString();
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
                WitnessFor = this.PartyFor == Entities.PartyFor.Party1 ? this.CourtCase.Party1.ConvertToDTO() : this.CourtCase.Party2.ConvertToDTO(),
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
