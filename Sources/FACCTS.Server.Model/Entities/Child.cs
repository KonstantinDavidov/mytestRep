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
    public class Child : PersonBase
    {
        public Child()
        {
            this.EntityType = FACCTSEntity.PERSON;
            this.RelationshipToProtected = Relationship.C;
        }

        public Relationship RelationshipToProtected { get; set; }

        public long? CourtCaseForChildId { get; set; }

        public CourtCase CourtCaseForChild { get; set; }
    }
}
