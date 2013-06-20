using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faccts.Model.Entities
{
    public partial class HairColor
    {
        public HairColor(FACCTS.Server.Model.DataModel.HairColor dto) : this()
        {
            this.Id = dto.Id;
            this.Color = dto.Color;
        }
    }
}
