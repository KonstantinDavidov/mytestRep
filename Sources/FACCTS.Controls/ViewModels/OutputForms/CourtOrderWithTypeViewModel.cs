using System.Collections.Generic;
using FACCTS.Server.Model;
using FACCTS.Server.Model.Enums;
using FACCTS.Server.Model.OrderModels;
using FACCTS.Services;
using FACCTS.Services.Data;

namespace FACCTS.Controls.ViewModels
{
    public class CourtOrderWithTypeViewModel: ViewModelBase
    {
        public CourtOrdersTypes OrderType { get; set; }

        public List<EnumDescript<OrderRestrictionState>> RestrictionStates
        {
            get { return EnumDescriptions.Instance.RestrictionStates; }
        }

        public List<EnumDescript<ParticipantRole>> ParticipantRoles
        {
            get
            {
                return EnumDescriptions.Instance.ParticipantRoles;
            }
        }

        public List<EnumDescript<Relationship>> Relationships
        {
            get
            {
                return EnumDescriptions.Instance.Relationships;
            }
        }

        public List<EnumDescript<CustodyParent>> CustodyParents
        {
            get
            {
                return EnumDescriptions.Instance.CustodyParents;
            }
        }
    }
}