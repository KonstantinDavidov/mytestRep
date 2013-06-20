using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faccts.Model.Entities
{
    public partial class EyesColor
    {
        public EyesColor(FACCTS.Server.Model.DataModel.EyesColor dto) : this()
        {
            this.Id = dto.Id;
            this.Color = dto.Color;
        }
    }
}
