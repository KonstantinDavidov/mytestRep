using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FACCTS.Server.Model.DataModel
{
    public class CodeToken : IEntityWithId, IEntityWithState
    {

        public string Code { get; set; }

        public long ClientId { get; set; }

        public string UserName { get; set; }

        public string Scope { get; set; }

        public int Type { get; set; }

        public DateTime TimeStamp { get; set; }

        public long Id { get; set; }

        [NotMapped]
        public ObjectState State { get; set; }
    }
}
