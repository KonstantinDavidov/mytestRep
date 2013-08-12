using System.Collections.Generic;
using FACCTS.Server.Model;
using FACCTS.Server.Model.Enums;

namespace FACCTS.Services.Data
{
    public class EnumDescriptions
    {
        public EnumDescriptions()
        {
            _restrictionStates = EnumDescript<OrderRestrictionState>.GetList();
            _paticipantRoles = EnumDescript<ParticipantRole>.GetList();
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

        public List<EnumDescript<ParticipantRole>> ParticipantRoles
        {
            get { return _paticipantRoles; }
        }
    }
}