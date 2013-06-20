using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faccts.Model.Entities
{
    public partial class Designation
    {
        public Designation(FACCTS.Server.Model.DataModel.Designation dto) : this()
        {
            this.Id = dto.Id;
            this.DesignationName = dto.DesignationName;
        }
    }
}
