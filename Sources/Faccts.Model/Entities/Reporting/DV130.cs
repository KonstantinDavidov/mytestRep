using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using FACCTS.Server.Model.Enums;
using FACCTS.Server.Model.OrderModels;

namespace Faccts.Model.Entities.Reporting
{
    public class DV130 : PermanentOrder, IDV130
    {
        private IDVAnimals _animals;
        private IDVConductChoice _conductChoice;
        private ICollection<IPaymentItem> _costs;
        private ICollection<IDebtPaymentItem> _debtPaymentItems;
        private bool _isAnimalsEnabled;
        private bool _isBattererIntervention;
        private bool _isChildCustodyAndVisitationEnabled;
        private bool _isConductChoiceEnabled;
        private bool _isDebtPaymentEnabled;
        private bool _isMoveoutEnabled;
        private bool _isNoGuns;
        private bool _isPosProvidedToCourt;
        private bool _isPropertyControlEnabled;
        private bool _isPropertyRestraintEnabled;
        private bool _isRecordUnlawfulCommunicationsAllowed;
        private bool _isStayAwayOrdersEnabled;
        private string _moveoutAddress;
        private IOtherOrders _otherOrders;
        private ICollection<IDataItem> _propertyControlItems;
        private IDVPropertyRestraint _propertyRestraint;
        private IDVStayAwayOrders _stayAwayOrders;

        public DV130()
        {
            ConductChoice = new DVConductChoice();
            StayAwayOrders = new DVStayAwayOrders();
            Animals = new DVAnimals();
            OtherOrders = new OtherOrders();
            PropertyControlItems = new ObservableCollection<IDataItem>();
            DebtPaymentItems = new ObservableCollection<IDebtPaymentItem>();
            PropertyRestraint = new DVPropertyRestraint();
            Costs = new ObservableCollection<IPaymentItem>();
            OrdersType = CourtOrdersTypes.DV130;
        }

        public DV130(IDV130 order)
            : base(order)
        {
            IsConductChoiceEnabled = order.IsConductChoiceEnabled;
            ConductChoice = new DVConductChoice(order.ConductChoice);
            IsStayAwayOrdersEnabled = order.IsStayAwayOrdersEnabled;
            StayAwayOrders = new DVStayAwayOrders(order.StayAwayOrders);
            IsPOSProvidedToCourt = order.IsPOSProvidedToCourt;
            IsMoveoutEnabled = order.IsMoveoutEnabled;
            MoveoutAddress = order.MoveoutAddress;
            IsRecordUnlawfulCommunicationsAllowed = order.IsRecordUnlawfulCommunicationsAllowed;
            IsAnimalsEnabled = order.IsAnimalsEnabled;
            Animals = new DVAnimals(order.Animals);
            OtherOrders = new OtherOrders(order.OtherOrders);
            IsBattererIntervention = order.IsBattererIntervention;
            IsNoGuns = order.IsNoGuns;
            IsPropertyControlEnabled = order.IsPropertyControlEnabled;
            PropertyControlItems =
                new ObservableCollection<IDataItem>(order.PropertyControlItems.Select(x => new DataItem(x)));
            IsDebtPaymentEnabled = order.IsDebtPaymentEnabled;
            DebtPaymentItems =
                new ObservableCollection<IDebtPaymentItem>(order.DebtPaymentItems.Select(x => new DebtPaymentItem(x)));
            IsPropertyRestraintEnabled = order.IsPropertyRestraintEnabled;
            PropertyRestraint = new DVPropertyRestraint(order.PropertyRestraint);
            Costs = new ObservableCollection<IPaymentItem>(order.Costs.Select(x => new PaymentItem(x)));
            IsChildCustodyAndVisitationEnabled = order.IsChildCustodyAndVisitationEnabled;
            OrdersType = CourtOrdersTypes.DV130;
        }

        public bool IsConductChoiceEnabled
        {
            get { return _isConductChoiceEnabled; }
            set
            {
                if (value.Equals(_isConductChoiceEnabled)) return;
                _isConductChoiceEnabled = value;
                OnPropertyChanged();
            }
        }

        public IDVConductChoice ConductChoice
        {
            get { return _conductChoice; }
            set
            {
                if (Equals(value, _conductChoice)) return;
                _conductChoice = value;
                OnPropertyChanged();
            }
        }

        public bool IsStayAwayOrdersEnabled
        {
            get { return _isStayAwayOrdersEnabled; }
            set
            {
                if (value.Equals(_isStayAwayOrdersEnabled)) return;
                _isStayAwayOrdersEnabled = value;
                OnPropertyChanged();
            }
        }

        public IDVStayAwayOrders StayAwayOrders
        {
            get { return _stayAwayOrders; }
            set
            {
                if (Equals(value, _stayAwayOrders)) return;
                _stayAwayOrders = value;
                OnPropertyChanged();
            }
        }

        public bool IsPOSProvidedToCourt
        {
            get { return _isPosProvidedToCourt; }
            set
            {
                if (value.Equals(_isPosProvidedToCourt)) return;
                _isPosProvidedToCourt = value;
                OnPropertyChanged();
            }
        }

        public bool IsMoveoutEnabled
        {
            get { return _isMoveoutEnabled; }
            set
            {
                if (value.Equals(_isMoveoutEnabled)) return;
                _isMoveoutEnabled = value;
                OnPropertyChanged();
            }
        }

        public string MoveoutAddress
        {
            get { return _moveoutAddress; }
            set
            {
                if (value == _moveoutAddress) return;
                _moveoutAddress = value;
                OnPropertyChanged();
            }
        }

        public bool IsRecordUnlawfulCommunicationsAllowed
        {
            get { return _isRecordUnlawfulCommunicationsAllowed; }
            set
            {
                if (value.Equals(_isRecordUnlawfulCommunicationsAllowed)) return;
                _isRecordUnlawfulCommunicationsAllowed = value;
                OnPropertyChanged();
            }
        }

        public bool IsAnimalsEnabled
        {
            get { return _isAnimalsEnabled; }
            set
            {
                if (value.Equals(_isAnimalsEnabled)) return;
                _isAnimalsEnabled = value;
                OnPropertyChanged();
            }
        }

        public IDVAnimals Animals
        {
            get { return _animals; }
            set
            {
                if (Equals(value, _animals)) return;
                _animals = value;
                OnPropertyChanged();
            }
        }

        public IOtherOrders OtherOrders
        {
            get { return _otherOrders; }
            set
            {
                if (Equals(value, _otherOrders)) return;
                _otherOrders = value;
                OnPropertyChanged();
            }
        }

        public bool IsBattererIntervention
        {
            get { return _isBattererIntervention; }
            set
            {
                if (value.Equals(_isBattererIntervention)) return;
                _isBattererIntervention = value;
                OnPropertyChanged();
            }
        }

        public bool IsNoGuns
        {
            get { return _isNoGuns; }
            set
            {
                if (value.Equals(_isNoGuns)) return;
                _isNoGuns = value;
                OnPropertyChanged();
            }
        }

        public bool IsPropertyControlEnabled
        {
            get { return _isPropertyControlEnabled; }
            set
            {
                if (value.Equals(_isPropertyControlEnabled)) return;
                _isPropertyControlEnabled = value;
                OnPropertyChanged();
            }
        }

        public ICollection<IDataItem> PropertyControlItems
        {
            get { return _propertyControlItems; }
            set
            {
                if (Equals(value, _propertyControlItems)) return;
                _propertyControlItems = value;
                OnPropertyChanged();
            }
        }

        public bool IsDebtPaymentEnabled
        {
            get { return _isDebtPaymentEnabled; }
            set
            {
                if (value.Equals(_isDebtPaymentEnabled)) return;
                _isDebtPaymentEnabled = value;
                OnPropertyChanged();
            }
        }

        public ICollection<IDebtPaymentItem> DebtPaymentItems
        {
            get { return _debtPaymentItems; }
            set
            {
                if (Equals(value, _debtPaymentItems)) return;
                _debtPaymentItems = value;
                OnPropertyChanged();
            }
        }

        public bool IsPropertyRestraintEnabled
        {
            get { return _isPropertyRestraintEnabled; }
            set
            {
                if (value.Equals(_isPropertyRestraintEnabled)) return;
                _isPropertyRestraintEnabled = value;
                OnPropertyChanged();
            }
        }

        public IDVPropertyRestraint PropertyRestraint
        {
            get { return _propertyRestraint; }
            set
            {
                if (Equals(value, _propertyRestraint)) return;
                _propertyRestraint = value;
                OnPropertyChanged();
            }
        }

        public ICollection<IPaymentItem> Costs
        {
            get { return _costs; }
            set
            {
                if (Equals(value, _costs)) return;
                _costs = value;
                OnPropertyChanged();
            }
        }

        public bool IsChildCustodyAndVisitationEnabled
        {
            get { return _isChildCustodyAndVisitationEnabled; }
            set
            {
                if (value.Equals(_isChildCustodyAndVisitationEnabled)) return;
                _isChildCustodyAndVisitationEnabled = value;
                OnPropertyChanged();
            }
        }
    }
}