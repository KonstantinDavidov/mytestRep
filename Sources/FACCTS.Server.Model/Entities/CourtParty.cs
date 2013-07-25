using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FACCTS.Server.Model.Enums;

namespace FACCTS.Server.Model.DataModel
{
    public class CourtParty : PersonBase
    {
        public CourtParty()
        {
            EntityType = FACCTSEntity.PERSON;
        }

        public string MiddleName { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public ParticipantRole ParticipantRole { get; set; }

        public Designation Designation { get; set; }

        public string ParentRole { get; set; }

        public long? HairColorId { get; set; }

        public virtual HairColor HairColor { get; set; }

        public long? EyesColorId { get; set; }

        public virtual EyesColor EyesColor { get; set; }

        public long? RaceId { get; set; }

        public virtual Race Race { get; set; }

        public string RelationToOtherParty { get; set; }

        public decimal Weight { get; set; }

        public decimal HeightFt { get; set; }

        public decimal HeightIns { get; set; }

        public virtual ICollection<Witness> Witnesses { get; set; }

        public long? InterpreterId { get; set; }

        public virtual Interpreter Interpreter { get; set; }

        public long? AttorneyId { get; set; }

        public virtual Attorney Attorney { get; set; }

        public bool IsProPer { get; set; }

        public string FullName
        {
            get
            {
                return string.Format("{0} {1} {2}",FirstName,MiddleName,this.LastName).Replace("  ", " ");
            }
        }
    }
}
