using FACCTS.Server.Model.OrderModels;

namespace Faccts.Model.Entities.Reporting
{
    public class ChildCustodyItem : ReactiveBase, IChildCustodyItem
    {
        private CustodyParent _physicalCustodyParent;
        private CustodyParent _legalCustodyParent;
        private long _childId;
        private Child _child;

        public ChildCustodyItem()
        {
        }

        public ChildCustodyItem(IChildCustodyItem item)
        {
            ChildId = item.ChildId;
            LegalCustodyParent = item.LegalCustodyParent;
            PhysicalCustodyParent = item.PhysicalCustodyParent;
        }

        public Child Child
        {
            get { return _child; }
            set
            {
                if (Equals(value, _child)) return;
                _child = value;
                OnPropertyChanged();
            }
        }

        public long ChildId
        {
            get { return _childId; }
            set
            {
                if (value == _childId) return;
                _childId = value;
                OnPropertyChanged();
            }
        }

        public CustodyParent LegalCustodyParent
        {
            get { return _legalCustodyParent; }
            set
            {
                if (value == _legalCustodyParent) return;
                _legalCustodyParent = value;
                OnPropertyChanged();
            }
        }

        public CustodyParent PhysicalCustodyParent
        {
            get { return _physicalCustodyParent; }
            set
            {
                if (value == _physicalCustodyParent) return;
                _physicalCustodyParent = value;
                OnPropertyChanged();
            }
        }
    }
}