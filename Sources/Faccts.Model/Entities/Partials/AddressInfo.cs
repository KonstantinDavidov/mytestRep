using Faccts.Model.Entities.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faccts.Model.Entities
{
    public partial class AddressInfo : IDataTransferConvertible<FACCTS.Server.Model.DataModel.AddressInfo>, IValidatableObject
    {
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
                ZipCode = dto.ZipCode;
                Phone = dto.Phone;
                Fax = dto.Fax;
            }
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
                propertyName = propertyName ?? string.Empty;
                return this.ValidateByPropertyName(_requiredFields, _errors, propertyName);
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
