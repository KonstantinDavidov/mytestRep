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
    public class Witness : PersonBase
    {
        public Witness()
        {
            EntityType = FACCTSEntity.PERSON;
        }

        public PartyFor WitnessFor { get; set; }

        public long? CourtCaseForWitnessId { get; set; }

        public CourtCase CourtCaseForWitness { get; set; }
    }
}
