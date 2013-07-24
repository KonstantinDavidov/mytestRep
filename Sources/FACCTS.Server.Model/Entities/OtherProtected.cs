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
    public class OtherProtected : PersonBase
    {
        public OtherProtected()
        {
            this.EntityType = FACCTSEntity.PERSON;
            this.RelationshipToPlaintiff = Relationship.O;
        }

        public Relationship RelationshipToPlaintiff { get; set; }

        public bool IsHouseHold { get; set; }

        public long? CourtCaseForOtherProtectedId { get; set; }

        public CourtCase CourtCaseForOtherProtected { get; set; }

        public string FullName
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }
    }
}
