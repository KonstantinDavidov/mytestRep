﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faccts.Model.Entities
{
    public partial class Courtrooms : IDataTransferConvertible<FACCTS.Server.Model.DataModel.CourtRoom>
    {
        public Courtrooms(FACCTS.Server.Model.DataModel.CourtRoom dto) : this()
        {
            if (dto == null)
            {
                this.Id = -1;
                this.RoomName = "<Not Specified>";
                this.JudgeName = "<Not Specified>";
                return;
            }
            this.Id = dto.Id;
            this.RoomName = dto.Name;
            this.JudgeName = dto.Judge != null ? string.Concat(dto.Judge.FirstName, " ", dto.Judge.MiddleName, " ", dto.Judge.LastName) : null;
            if (dto.CourtLocation != null)
            {
                this.CourtLocation_Id = dto.CourtLocation.Id;
            }
            
        }

        public FACCTS.Server.Model.DataModel.CourtRoom ToDTO()
        {
            if (!this.IsDirty)
                return null;
            return new FACCTS.Server.Model.DataModel.CourtRoom()
            {
                Id = this.Id,
                Name = this.RoomName,
                CourtLocation = this.CourtLocations.ConvertToDTO(),
                State = (FACCTS.Server.Model.DataModel.ObjectState)(int)this.ChangeTracker.State,
                //JudgeId = this.JudgeId,
            };
        }

        private static Courtrooms _empty = new Courtrooms() {
            Id = -1,
            RoomName = "All",
        };
        public static Courtrooms Empty
        {
            get
            {
                return _empty;
            }
        }

        public override bool Equals(object obj)
        {
            // Check for null
            if (obj == null) return false;

            // Check for type
            if (this.GetType() != obj.GetType()) return false;

            // Cast as Employee
            Courtrooms courtRoom = (Courtrooms)obj;

            return (this == courtRoom);
        }

        public static bool operator ==(Courtrooms left, Courtrooms right)
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
            if (left.RoomName != right.RoomName)
                return false;
            if (left.JudgeName != right.JudgeName)
                return false;
            if (left.CourtLocation_Id != right.CourtLocation_Id)
            {
                return false;
            }

            return true;
        }

        public static bool operator !=(Courtrooms left, Courtrooms right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode() ^
                this.RoomName.ThisOrEmpty().GetHashCode() ^
                this.JudgeName.ThisOrEmpty().GetHashCode() &
                this.CourtLocation_Id.GetValueOrDefault(0).GetHashCode();
        }

    }
}
