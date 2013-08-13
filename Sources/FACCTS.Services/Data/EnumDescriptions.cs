using System.Collections.Generic;
using FACCTS.Server.Model;
using FACCTS.Server.Model.Enums;
using FACCTS.Server.Model.OrderModels;

namespace FACCTS.Services.Data
{
    public class EnumDescriptions
    {
        public EnumDescriptions()
        {
            _restrictionStates = EnumDescript<OrderRestrictionState>.GetList();
            _paticipantRoles = EnumDescript<ParticipantRole>.GetList();
            _relationships = EnumDescript<Relationship>.GetList();
            _custodyParents = EnumDescript<CustodyParent>.GetList();
        }

        private static readonly object _instanceLock = new object();

        private static volatile EnumDescriptions _instance;

        public static EnumDescriptions Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_instanceLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new EnumDescriptions();
                        }
                    }
                }
                return _instance;
            }
        }

        private List<EnumDescript<OrderRestrictionState>> _restrictionStates;

        public List<EnumDescript<OrderRestrictionState>> RestrictionStates
        {
            get { return _restrictionStates; }
        }

        private List<EnumDescript<ParticipantRole>> _paticipantRoles;
        private List<EnumDescript<Relationship>> _relationships;
        private List<EnumDescript<CustodyParent>> _custodyParents;

        public List<EnumDescript<ParticipantRole>> ParticipantRoles
        {
            get { return _paticipantRoles; }
        }

        public List<EnumDescript<Relationship>> Relationships { get { return _relationships; } }

        public List<EnumDescript<CustodyParent>> CustodyParents
        {
            get { return _custodyParents; }
        }
    }
}