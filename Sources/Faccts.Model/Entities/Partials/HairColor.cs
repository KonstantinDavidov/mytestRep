using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faccts.Model.Entities
{
    public partial class HairColor : IDataTransferConvertible<FACCTS.Server.Model.DataModel.HairColor>
    {
        partial void Initialize()
        {
            this.MarkAsUnchanged();
            this.ChangeTracker.ChangeTrackingEnabled = false;
        }

        public HairColor(FACCTS.Server.Model.DataModel.HairColor dto) : this()
        {
            if (dto != null)
            {
                this.Id = dto.Id;
                this.Color = dto.Color;
            }
            
        }

        public FACCTS.Server.Model.DataModel.HairColor ToDTO()
        {
            if (!this.IsDirty)
                return null;
            return new FACCTS.Server.Model.DataModel.HairColor()
            {
                Id = this.Id,
                Color = this.Color,
                State = (FACCTS.Server.Model.DataModel.ObjectState)this.ChangeTracker.State,
            };
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode() ^ (this.Color ?? string.Empty).GetHashCode();
        }

        public override bool Equals(object obj)
        {
            // Check for null
            if (obj == null) return false;

            // Check for type
            if (this.GetType() != obj.GetType()) return false;

            // Cast as Employee
            HairColor employee = (HairColor)obj;

            return (this == employee);
        }

        public static bool operator ==(HairColor left, HairColor right)
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
            if (left.Color != right.Color)
                return false;

            return true;
        }

        public static bool operator !=(HairColor left, HairColor right)
        {
            return !(left == right);
        }

    }
}
