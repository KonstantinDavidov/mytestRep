using FACCTS.Server.Model.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FACCTS.Server.Model.DataModel
{
    public partial class CodeToken : BaseEntity
    {

        public string Code { get; set; }

        public long ClientId { get; set; }

        public string UserName { get; set; }

        public string Scope { get; set; }

        public int Type { get; set; }

        public DateTime TimeStamp { get; set; }

        [NotMapped]
        public override ObjectState State
        {
            get
            {
                return base.State;
            }
            set
            {
                base.State = value;
            }
        }
    }
}
