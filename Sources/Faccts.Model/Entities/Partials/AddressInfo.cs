using Faccts.Model.Entities.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace Faccts.Model.Entities
{
    public partial class AddressInfo : IDataTransferConvertible<FACCTS.Server.Model.DataModel.AddressInfo>, IValidatableObject
    {
        partial void Initialize()
        {
            this.WhenAny(x => x.IsValidationEnabled, x => x.Value)
                .Subscribe(x =>
                {
                    if (!x)
                    {
                        this._errors.Clear();
                    }
                }
                );
        }

        public FACCTS.Server.Model.DataModel.AddressInfo ToDTO()
        {
            return new FACCTS.Server.Model.DataModel.AddressInfo()
            {
                StreetAddress = this.StreetAddress,
                City = this.City,
                USAState = this.USAState,
                ZipCode = this.ZipCode,
                Phone = this.Phone,
                Fax = this.Fax,
                AddressType = this.AddressType,
            };
        }

        public AddressInfo(FACCTS.Server.Model.DataModel.AddressInfo dto)
            : this()
        {
            if (dto != null)
            {
                StreetAddress = dto.StreetAddress;
                City = dto.City;
                USAState = dto.USAState;
                Phone = dto.Phone;
                ZipCode = dto.ZipCode;
                Fax = dto.Fax;
                AddressType = dto.AddressType;
            }
        }

        public override bool Equals(object obj)
        {
            // Check for null
            if (obj == null) return false;

            // Check for type
            if (this.GetType() != obj.GetType()) return false;

            // Cast as Employee
            AddressInfo addressInfo = (AddressInfo)obj;

            return (this == addressInfo);
        }

        public override int GetHashCode()
        {
            return
                (this.StreetAddress ?? string.Empty).GetHashCode() ^
                (this.City ?? string.Empty).GetHashCode() ^
                this.USAState.GetHashCode() ^
                (this.ZipCode ?? string.Empty).GetHashCode() ^
                (this.Phone ?? string.Empty).GetHashCode() ^
                (this.Fax ?? string.Empty).GetHashCode();
        }

        public static bool operator !=(AddressInfo left, AddressInfo right)
        {
            return !(left == right);
        }

        public static bool operator ==(AddressInfo left, AddressInfo right)
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

            if (left.StreetAddress != right.StreetAddress)
                return false;
            if (left.City != right.City)
                return false;
            if (left.USAState != right.USAState)
                return false;
            if (left.ZipCode != right.ZipCode)
                return false;
            if (left.Phone != right.Phone)
                return false;
            if (left.Fax != right.Fax)
                return false;

            return true;
        }

        private Dictionary<string, string> _errors = new Dictionary<string, string>();
        public IList<string> Errors
        {
            get { return _errors.Values.ToList().AsReadOnly(); }
        }

        public bool IsValid
        {
            get { return !this.Error.Any(); }
        }

        public string Error
        {
            get { return this.Errors.FirstOrDefault(); }
        }

        public string this[string propertyName]
        {
            get 
            {
                if (!this.IsValidationEnabled)
                    return null;
                propertyName = propertyName ?? string.Empty;
                return this.ValidateByPropertyName(_requiredFields, _errors, propertyName);
            }
        }

        private bool _isValidationEnabled = true;
        public virtual bool IsValidationEnabled
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
                {"StreetAddress", "Street Address"},
                {"City", "City"},
                {"USAState", "State"},
                {"ZipCode", "Zip Code"},
            };

    }
}
