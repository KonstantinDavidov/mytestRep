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
        public Attorneys() : base()
        {
            this.AddressInfo = new AddressInfo();
        }

        public Attorneys(FACCTS.Server.Model.DataModel.Attorney dto)
        {
            if (dto != null)
            {
                this.Id = dto.Id;
                this.FirstName = dto.FirstName;
                this.LastName = dto.LastName;
                this.AddressInfo = new AddressInfo(dto.AddressInfo);
                this.FirmName = dto.FirmName;
                this.StateBarId = dto.StateBarId;
                this.Email = dto.Email;
                
                this.MarkAsUnchanged();
            }
            
        }

        public FACCTS.Server.Model.DataModel.Attorney ToDTO()
        {
            if (!this.IsDirty)
                return null;
            return new FACCTS.Server.Model.DataModel.Attorney()
            {
                Id = this.Id,
                FirstName = this.FirstName,
                LastName = this.LastName,
                AddressInfo = this.AddressInfo.ConvertToDTO(),
                Email = this.Email,
                FirmName = this.FirmName,
                StateBarId = this.StateBarId,
                State = (FACCTS.Server.Model.DataModel.ObjectState)(int)this.ChangeTracker.State,
            };
        }

        public override string this[string propertyName]
        {
            get 
            {
                if ((this.CourtParty == null || this.CourtParty.IsProPer)  && !this.ThirdPartyData.Any() && !this.CourtCases.Any())
                {
                    return null;
                }
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
            {"AddressInfo.StreetAddress", "Street Address"},
            {"AddressInfo.City", "City"},
            {"AddressInfo.USAState", "State"},
            {"AddressInfo.ZipCode", "Zip Code"},
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
