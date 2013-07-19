using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace Faccts.Model.Entities
{
    public partial class RestrainingPartyIDInfo : IDataTransferConvertible<FACCTS.Server.Model.DataModel.RestrainingPartyIdentificationInformation>
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

        public FACCTS.Server.Model.Enums.IdentificationIDType IDTypeEnum
        {
            get
            {
                return this.IDType;
            }
            set
            {
                this.IDType = value;
            }
        }

        private DateTime? _IDIssuedDateNullable;
        public DateTime? IDIssuedDateNullable
        {
            get
            {
                if (DateTime.Now.Subtract(TimeSpan.FromDays(365 * 200)) >= this.IDIssuedDate)
                {
                    _IDIssuedDateNullable = null;
                }
                else
                {
                    _IDIssuedDateNullable = this.IDIssuedDate;
                }
                return _IDIssuedDateNullable;
            }
            set
            {
                if (_IDIssuedDateNullable == value)
                    return;

                this.OnPropertyChanging("IDIssuedDate");
                _IDIssuedDateNullable = value;
                if (_IDIssuedDateNullable.HasValue)
                {
                    this.IDIssuedDate = _IDIssuedDateNullable.Value;
                }
                this.OnPropertyChanged("IDIssuedDate");
            }
        }

        public FACCTS.Server.Model.DataModel.RestrainingPartyIdentificationInformation ToDTO()
        {
            if (!this.IsDirty)
                return null;
            return new FACCTS.Server.Model.DataModel.RestrainingPartyIdentificationInformation()
            {
                IDNumber = this.IDNumber,
                IDType = this.IDType,
                IssuedDate = this.IDIssuedDate,
            };
        }
    }
}
