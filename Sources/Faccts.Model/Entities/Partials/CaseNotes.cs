using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace Faccts.Model.Entities
{
    public partial class CaseNotes : IDataTransferConvertible<FACCTS.Server.Model.DataModel.CaseNote>
    {
        partial void Initialize()
        {
            this.WhenAny(x => x.Status, x => x.Value)
                .Subscribe(x =>
                {
                    this.OnPropertyChanged("IsPublic");
                }
                );
        }

        public bool IsPublic
        {
            get
            {
                return (FACCTS.Server.Model.Enums.CaseNoteStatus)this.Status == FACCTS.Server.Model.Enums.CaseNoteStatus.Public;
            }
            set
            {
                this.Status = FACCTS.Server.Model.Enums.CaseNoteStatus.Public;
            }
        }

        public FACCTS.Server.Model.DataModel.CaseNote ToDTO()
        {
            if (!this.IsDirty)
                return null;
            return new FACCTS.Server.Model.DataModel.CaseNote()
            {
                Id = this.Id,
                Author = this.User.ConvertToDTO(),
                Status = this.Status,
                Text = this.Text,
                State = (FACCTS.Server.Model.DataModel.ObjectState)(int)this.ChangeTracker.State,
            };
        }

    }
}
