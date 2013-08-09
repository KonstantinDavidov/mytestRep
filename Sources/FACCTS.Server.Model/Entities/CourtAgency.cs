using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.DataModel
{
    public class CourtAgency : IEntityWithId, IEntityWithState
    {
        public long Id { get; set; }

        [NotMapped]
        public ObjectState State { get; set; }

        public string Name { get; set; }
        public string ORI { get; set; }

    }
}
