using FACCTS.Server.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.Reporting.Entities
{
    public class ChildCustodyItem
    {
        public long ChildId { get; set; }
        public CustodyParent LegalCustodyParent { get; set; }
        public CustodyParent PhysicalCustodyParent { get; set; }
    }
}
