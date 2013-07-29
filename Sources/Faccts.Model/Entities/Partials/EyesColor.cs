using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faccts.Model.Entities
{
    public partial class EyesColor : IDataTransferConvertible<FACCTS.Server.Model.DataModel.EyesColor>
    {
        partial void Initialize()
        {
            this.MarkAsUnchanged();
            this.ChangeTracker.ChangeTrackingEnabled = false;
        }

        public EyesColor(FACCTS.Server.Model.DataModel.EyesColor dto) : this()
        {
            if (dto != null)
            {
                this.Id = dto.Id;
                this.Color = dto.Color;
            }
            
        }

        public FACCTS.Server.Model.DataModel.EyesColor ToDTO()
        {
            if (!this.IsDirty)
                return null;
            return new FACCTS.Server.Model.DataModel.EyesColor()
            {
                Id = this.Id,
                Color = this.Color,
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
            EyesColor eyesColor = (EyesColor)obj;

            return (this == eyesColor);
        }

        public static bool operator ==(EyesColor left, EyesColor right)
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

        public static bool operator !=(EyesColor left, EyesColor right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode() ^ (this.Color ?? string.Empty).GetHashCode();
        }

    }
}
