using FACCTS.Server.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.DataModel
{
    [Table("CaseNotes")]
    public class CaseNote : IEntityWithId, IEntityWithState
    {
        public long AuthorId { get; set; }

        public virtual User Author { get; set; }

        [EnumDataType(typeof(CaseNoteStatus))]
        public CaseNoteStatus Status { get; set; }

        public string Text { get; set; }

        public long CourtCaseId { get; set; }

        public virtual CourtCase CourtCase { get; set; }

        public long Id { get; set; }

        public ObjectState State { get; set; }
    }
}
