using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using System.ComponentModel;

namespace Faccts.Model.Entities
{
    public partial class RestrainingPartyIDInfo : IDataTransferConvertible<FACCTS.Server.Model.DataModel.RestrainingPartyIdentificationInformation>, IDataErrorInfo
    {
        partial void Initialize()
        {
            this.WhenAny(x => x.IDType, x => x.Value)
                .Subscribe(x =>
                {
                    this.OnPropertyChanged("IDTypeEnum");
                }
                );
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
                propertyName = propertyName ?? string.Empty;
                return this.ValidateByPropertyName(_requiredFields, propertyName);
            }
        }

        

        private static Dictionary<string, string> _requiredFields = new Dictionary<string, string>()
        {
            {"IDType", "ID Type"},
            {"IDIssuedDate", "Issued Date"},
            {"IDNumber", "ID Number"}
        };
    }
}
