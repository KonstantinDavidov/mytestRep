using Caliburn.Micro;
using Faccts.Model.Entities;
using FACCTS.Controls.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using FACCTS.Services;
using FACCTS.Services.Authentication;
using FACCTS.Services.Data;
using System.Reactive.Linq;

namespace FACCTS.Controls.ViewModels
{
    [Export(typeof(PersonalInformationViewModel))]
    public partial class PersonalInformationViewModel : CaseRecordItemViewModel
    {
        
        [ImportingConstructor]
        public PersonalInformationViewModel() : base()
        {
            this.DisplayName = "Personal Information";
        }

        private IDisposable _subscriber;
        public override CourtCase CurrentCourtCase
        {
            get
            {
                return base.CurrentCourtCase;
            }
            set
            {
                if (base.CurrentCourtCase == value)
                    return;
                if (_subscriber != null)
                {
                    _subscriber.Dispose();
                    _subscriber = null;
                }
                base.CurrentCourtCase = value;
                if (base.CurrentCourtCase != null)
                {
                    _subscriber = base.CurrentCourtCase.CaseRecord.WhenAny(x => x.CourtParty.IsDirty, y => y.CourtParty1.IsDirty, z => z.RestrainingpartyIdentificationInformation.IsDirty, (x, y, z) => x.Value || y.Value || z.Value)
                        .Subscribe(x =>
                        {
                            this.IsDirty = x;
                        }
                        );
                }
            }
        }

        private List<EnumDescript<FACCTS.Server.Model.Enums.IdentificationIDType>> _identificationIDTypes;
        public List<EnumDescript<FACCTS.Server.Model.Enums.IdentificationIDType>> IdentificationIDTypes
        {
            get
            {
                if (_identificationIDTypes == null)
                {
                    _identificationIDTypes = Enum.GetValues(typeof(FACCTS.Server.Model.Enums.IdentificationIDType))
                        .Cast<FACCTS.Server.Model.Enums.IdentificationIDType>()
                        .Select(x => new EnumDescript<FACCTS.Server.Model.Enums.IdentificationIDType>(x))
                        .ToList();
                }
                return _identificationIDTypes;
            }
        }

    }
}
