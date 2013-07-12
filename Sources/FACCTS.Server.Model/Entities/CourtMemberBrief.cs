using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.DataModel
{
    public class CourtMemberBrief : BaseEntity
    {
        public string FullName { get; set; }
        public string RoleName { get; set; }
        public long UserId { get; set; }
        public string Email { get; set; }
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
