using FACCTS.Server.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace Faccts.Model.Entities
{
    public partial class CaseRecord
    {
        partial void Initialize()
        {
            this.CaseHistory = new TrackableCollection<CaseHistory>();
            this.CaseNotes = new TrackableCollection<CaseNotes>();
            this.Witnesses = new TrackableCollection<Witnesses>();
            this.Interpreters = new TrackableCollection<Interpreters>();
            this.OtherProtected = new TrackableCollection<OtherProtected>();
            this.CourtParty1 = new CourtParty();
            this.CourtParty = new CourtParty();
            this.Attorneys = new Attorneys();
            this.Children = new TrackableCollection<Children>();
            this.RestrainingpartyIdentificationInformation = new RestrainingPartyIDInfo();
            this.ThirdPartyData = new ThirdPartyData();
            this.WhenAny(x => x.CourtParty.IsDirty, x => x.CourtParty1.IsDirty, x => x.RestrainingpartyIdentificationInformation.IsDirty,
                (x1, x2, x3) => x1.Value || x2.Value || x3.Value
                )
                .Subscribe(x =>
                    {
                        this.OnPropertyChanging("IsPersonalInformationDirty");
                        this.OnPropertyChanged("IsPersonalInformationDirty");
                    }
                );
        }

        

        public DateTime? FileDate
        {
            get
            {
                if (this.CaseHistory == null || !CaseHistory.Any())
                {
                    return null;
                }
                var fileEvent = CaseHistory.FirstOrDefault(x => x.CaseHistoryEvent == (int)CaseHistoryEvent.New);
                if (fileEvent == null)
                    return null;
                return fileEvent.Date;
            }
        }

        public bool IsPersonalInformationDirty
        {
            get
            {
                return this.CourtParty.IsDirty || this.CourtParty1.IsDirty || this.RestrainingpartyIdentificationInformation.IsDirty;
            }
        }

        public FACCTS.Server.Model.DataModel.CaseRecord ToDTO()
        {
            return new FACCTS.Server.Model.DataModel.CaseRecord()
            {
                Id = this.Id,
                Party1 = this.CourtParty.ToDTO(),
                Party2 = this.CourtParty.ToDTO(),
                RestrainingPartyIdentificationInformation = this.RestrainingpartyIdentificationInformation.ToDTO(),
                //TODO: implement another properties
                State = (FACCTS.Server.Model.DataModel.ObjectState)(int)this.ChangeTracker.State,
            };
        }
    }
}
