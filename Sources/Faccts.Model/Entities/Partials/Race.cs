using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faccts.Model.Entities
{
    public partial class Race
    {
        public Race(FACCTS.Server.Model.DataModel.Race dto) : this()
        {
            this.Id = dto.Id;
            this.RaceName = dto.RaceName;
        }
    }
}
