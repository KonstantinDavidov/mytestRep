using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faccts.Model.Entities
{
    public partial class Sex
    {
        public Sex(FACCTS.Server.Model.DataModel.Sex dto) : this()
        {
            this.Id = dto.Id;
            this.SexName = dto.SexName;
        }
    }
}
