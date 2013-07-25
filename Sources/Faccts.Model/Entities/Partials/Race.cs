using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faccts.Model.Entities
{
    public partial class Race : IDataTransferConvertible<FACCTS.Server.Model.DataModel.Race>
    {
        partial void Initialize()
        {
            this.MarkAsUnchanged();
            this.ChangeTracker.ChangeTrackingEnabled = false;
        }

        public Race(FACCTS.Server.Model.DataModel.Race dto) : this()
        {
            if (dto != null)
            {
                this.Id = dto.Id;
                this.RaceName = dto.RaceName;
            }
            
        }

        public FACCTS.Server.Model.DataModel.Race ToDTO()
        {
            if (!this.IsDirty)
                return null;
            return new FACCTS.Server.Model.DataModel.Race()
            {
                Id = this.Id,
                RaceName = this.RaceName,
                State = (FACCTS.Server.Model.DataModel.ObjectState)this.ChangeTracker.State,
            };
        }

        public override bool Equals(object obj)
        {
            // Check for null
            if (obj == null) return false;

            // Check for type
            if (this.GetType() != obj.GetType()) return false;

            // Cast as Employee
            Race race = (Race)obj;

            return (this == race);
        }

        public static bool operator ==(Race left, Race right)
        {
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(left, right))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)left == null) || ((object)right == null))
            {
                return false;
            }

            if (left.Id != right.Id)
                return false;
            if (left.RaceName != right.RaceName)
                return false;

            return true;
        }

        public static bool operator !=(Race left, Race right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode() ^ (this.RaceName ?? string.Empty).GetHashCode();
        }

    }
}
