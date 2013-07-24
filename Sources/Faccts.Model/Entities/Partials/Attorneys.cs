using Faccts.Model.Entities.Validation;
using FACCTS.Server.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faccts.Model.Entities
{
    public partial class Attorneys : IDataTransferConvertible<FACCTS.Server.Model.DataModel.Attorney>, IValidatableObject
    {
        public FACCTS.Server.Model.DataModel.Attorney ToDTO()
        {
            if (!this.IsDirty)
                return null;
            return new FACCTS.Server.Model.DataModel.Attorney()
            {
                Id = this.Id,
                FirstName = this.FirstName,
                LastName = this.LastName,
                AddressInfo = new FACCTS.Server.Model.DataModel.AddressInfo
                {
                    City = this.City,
                    Fax = this.Fax,
                    Phone = this.Phone,
                    USAState = (USAState)this.USAState,
                    StreetAddress = this.StreetAddress,
                    ZipCode = this.ZipCode,
                },
                Email = this.Email,
                FirmName = this.FirmName,
                StateBarId = this.StateBarId,
                State = (FACCTS.Server.Model.DataModel.ObjectState)(int)this.ChangeTracker.State,
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
                propertyName = propertyName ?? string.Empty;
                return this.ValidateByPropertyName(_requiredFields, _errors, propertyName);
            }
        }

        private static Dictionary<string, string> _requiredFields = new Dictionary<string, string>()
        {
            {"FirstName", "First Name"},
            {"LastName", "Last Name"},
            {"StateBarId", "State Bar Id"},
            {"FirmName", "Firm Name"},
            {"StreetAddress", "Street Address"},
            {"City", "City"},
            {"State", "State"},
            {"ZipCode", "Zip Code"},
            {"Phone", "Phone"},
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
    }
}
