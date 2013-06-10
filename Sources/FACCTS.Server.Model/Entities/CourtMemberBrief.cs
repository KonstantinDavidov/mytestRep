using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.DataModel
{
    public class CourtMemberBrief
    {
        public string FullName { get; set; }
        public string RoleName { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }
    }
}
