using System.Collections.Generic;
using FACCTS.Server.Model.Enums;
using FACCTS.Server.Model.OrderModels;
using FACCTS.Server.Model.Reporting.Entities;

namespace Faccts.Model.Entities.Reporting
{
    public class CAPROSEntry : ReactiveBase, ICAPROSEntry
    {
        private CARPOSEntryType _carposEntryType;
        private ICollection<IDataItem> _lawEnforcementAgencies;

        public CAPROSEntry()
        {
        }

        public CAPROSEntry(ICAPROSEntry entry)
        {
            CARPOSEntryType = entry.CARPOSEntryType;
            LawEnforcementAgencies = entry.LawEnforcementAgencies;
        }

        public CARPOSEntryType CARPOSEntryType
        {
            get { return _carposEntryType; }
            set
            {
                if (value == _carposEntryType) return;
                _carposEntryType = value;
                OnPropertyChanged();
            }
        }

        public ICollection<IDataItem> LawEnforcementAgencies
        {
            get { return _lawEnforcementAgencies; }
            set
            {
                if (Equals(value, _lawEnforcementAgencies)) return;
                _lawEnforcementAgencies = value;
                OnPropertyChanged();
            }
        }
    }
}