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
            this.WhenAny(x => x.User,
                x => x.Status,
                x => x.Text,
                (x1, x2, x3) => new { User = x1.Value, Status = x2.Value, Text = x3.Value }
                ).Subscribe(_ =>
                {
                    if (this.CourtCase != null)
                    {
                        this.CourtCase.IsDirty = true;
                    }
                    
                }
                );
        }

        public CaseNotes(FACCTS.Server.Model.DataModel.CaseNote dto)
            : this()
        {
            if (dto != null)
            {
                this.Id = dto.Id;
                this.User = new User(dto.Author);
                this.Status = dto.Status;
                this.Text = dto.Text;

                this.MarkAsUnchanged();
            }
            
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
                AuthorId = this.Author_Id.GetValueOrDefault(0),
                Status = this.Status,
                Text = this.Text,
                State = (FACCTS.Server.Model.DataModel.ObjectState)(int)this.ChangeTracker.State,
            };
        }

    }
}
