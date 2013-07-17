using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faccts.Model.Entities
{
    public partial class Child
    {
        public Child() : base()
        {
            this.RelationToProtected = FACCTS.Server.Model.Enums.Relationship.C;
        }
    }
}
