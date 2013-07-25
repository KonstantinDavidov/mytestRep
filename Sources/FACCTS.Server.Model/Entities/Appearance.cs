using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.DataModel
{
    public class Appearance : IEntityWithState
    {
        public long PersonId { get; set; }

        public virtual PersonBase Person { get; set; }

        public long HearingId { get; set; }

        public virtual Hearing Hearing { get; set; }

        public ObjectState State { get; set; }
    }
}
