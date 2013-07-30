using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using System.ComponentModel;
using Faccts.Model.Entities.Validation;

namespace Faccts.Model.Entities
{
    public partial class RestrainingPartyIDInfo : IDataTransferConvertible<FACCTS.Server.Model.DataModel.RestrainingPartyIdentificationInformation>, IValidatableObject
    {
        partial void Initialize()
        {
            this.WhenAny(x => x.IDType, x => x.Value)
                .Subscribe(x =>
                {
                    this.OnPropertyChanged("IDTypeEnum");
                }
                );
            this.WhenAny(x => x.IsValidationEnabled, x => x.Value)
                .Subscribe(x =>
                {
                    if (!x)
                        this._errors.Clear();
                }
                );
        }

        public RestrainingPartyIDInfo(FACCTS.Server.Model.DataModel.RestrainingPartyIdentificationInformation dto)
            : this()
        {
            if (dto != null)
            {
                this.IDType = dto.IDType;
                this.IDNumber = dto.IDNumber;
                this.IDIssuedDate = dto.IssuedDate;
            }
        }


        public FACCTS.Server.Model.DataModel.RestrainingPartyIdentificationInformation ToDTO()
        {
            return new FACCTS.Server.Model.DataModel.RestrainingPartyIdentificationInformation()
            {
                IDNumber = this.IDNumber,
                IDType = this.IDType,
                IssuedDate = this.IDIssuedDate,
            };
        }


        public string Error
        {
            get { return this[string.Empty]; }
        }

        public string this[string propertyName]
        {
            get
            {
                if (!IsValidationEnabled)
                    return null;
                propertyName = propertyName ?? string.Empty;
                return this.ValidateByPropertyName(_requiredFields, _errors, propertyName);
            }
        }

        private bool _isValidationEnabled = true;
        public bool IsValidationEnabled
        {
            get
            {
                return _isValidationEnabled;
            }
            set
            {
                if (_isValidationEnabled == value)
                    return;

                this.OnPropertyChanging("IsValidationInabled");
                _isValidationEnabled = value;
                this.OnPropertyChanged("IsValidationInabled");
            }
        }

        

        private static Dictionary<string, string> _requiredFields = new Dictionary<string, string>()
        {
            {"IDType", "ID Type"},
            {"IDIssuedDate", "Issued Date"},
            {"IDNumber", "ID Number"}
        };

        private Dictionary<string, string> _errors = new Dictionary<string, string>();
        public IList<string> Errors
        {
            get { return _errors.Values.ToList().AsReadOnly(); }
        }

        public bool IsValid
        {
            get { return !Errors.Any(); }
        }

        public override bool Equals(object obj)
        {
            // Check for null
            if (obj == null) return false;

            // Check for type
            if (this.GetType() != obj.GetType()) return false;

            // Cast as Employee
            RestrainingPartyIDInfo info = (RestrainingPartyIDInfo)obj;

            return (this == info);
        }

        public static bool operator !=(RestrainingPartyIDInfo left, RestrainingPartyIDInfo right)
        {
            return !(left == right);
        }

        public static bool operator ==(RestrainingPartyIDInfo left, RestrainingPartyIDInfo right)
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

            if (left.IDType != right.IDType)
                return false;
            if (left.IDNumber != right.IDNumber)
                return false;
            if (left.IDIssuedDate != right.IDIssuedDate)
                return false;

            return true;
        }

        public override int GetHashCode()
        {
            return
                this.IDType.GetHashCode() ^
                (this.IDNumber ?? string.Empty).GetHashCode() ^
                this.IDIssuedDate.GetValueOrDefault().GetHashCode();
        }

       
    }
}
