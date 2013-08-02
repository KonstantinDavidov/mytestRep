using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using FACCTS.Server.Model;
using FACCTS.Server.Model.OrderModels;
using FACCTS.Server.Model.Reporting.Entities;

namespace Faccts.Model.Entities.Reporting
{
    public class DV110 : TemporaryOrder, IDV110
    {
        private IDVAnimals _animalsSection;
        private OrderRestrictionState _animalsSectionState;
        private OrderRestrictionState _childCustodyAndVisitationState;
        private IDVConductChoice _conductChoice;
        private OrderRestrictionState _conductChoiceState;
        private ICollection<IDebtPaymentItem> _debtPaymentItems;
        private OrderRestrictionState _debtPaymentState;
        private OrderRestrictionState _dvPropertyRestraintState;
        private bool _isNoGuns;
        private bool _isOterordersAttached;
        private string _moveoutAddress;
        private OrderRestrictionState _moveoutState;
        private string _otherOrdersDescription;
        private OrderRestrictionState _otherOrdersState;
        private ICollection<IDataItem> _propertyControlItems;
        private OrderRestrictionState _propertyControlState;
        private IDVPropertyRestraint _propertyRestraint;
        private OrderRestrictionState _recordUnlawfulCommunicationsAllowedState;
        private IDVStayAwayOrders _stayAwayOrders;
        private OrderRestrictionState _stayAwayOrdersState;

        public DV110()
        {
            ConductChoice = new DVConductChoice();
            StayAwayOrders = new DVStayAwayOrders();
            AnimalsSection = new DVAnimals();
            PropertyControlItems = new ObservableCollection<IDataItem>();
            DebtPaymentItems = new ObservableCollection<IDebtPaymentItem>();
            PropertyRestraint = new DVPropertyRestraint();
        }

        public DV110(IDV110 order) : base(order)
        {
            ConductChoiceState = order.ConductChoiceState;
            ConductChoice = new DVConductChoice(order.ConductChoice);
            StayAwayOrdersState = order.StayAwayOrdersState;
            StayAwayOrders = new DVStayAwayOrders(order.StayAwayOrders);
            MoveoutState = order.MoveoutState;
            MoveoutAddress = order.MoveoutAddress;
            RecordUnlawfulCommunicationsAllowedState = order.RecordUnlawfulCommunicationsAllowedState;
            AnimalsSectionState = order.AnimalsSectionState;
            AnimalsSection = new DVAnimals(order.AnimalsSection);
            IsNoGuns = order.IsNoGuns;
            OtherOrdersState = order.OtherOrdersState;
            OtherOrdersDescription = order.OtherOrdersDescription;
            IsOterordersAttached = order.IsOterordersAttached;
            PropertyControlState = order.PropertyControlState;
            PropertyControlItems =
                new ObservableCollection<IDataItem>(order.PropertyControlItems.Select(i => new DataItem(i)));
            DebtPaymentState = order.DebtPaymentState;
            DebtPaymentItems =
                new ObservableCollection<IDebtPaymentItem>(order.DebtPaymentItems.Select(i => new DebtPaymentItem(i)));
            DVPropertyRestraintState = order.DVPropertyRestraintState;
            PropertyRestraint = new DVPropertyRestraint(order.PropertyRestraint);
            ChildCustodyAndVisitationState = order.ChildCustodyAndVisitationState;
        }

        public OrderRestrictionState ConductChoiceState
        {
            get { return _conductChoiceState; }
            set
            {
                if (value == _conductChoiceState) return;
                _conductChoiceState = value;
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

        public OrderRestrictionState StayAwayOrdersState
        {
            get { return _stayAwayOrdersState; }
            set
            {
                if (value == _stayAwayOrdersState) return;
                _stayAwayOrdersState = value;
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

        public OrderRestrictionState MoveoutState
        {
            get { return _moveoutState; }
            set
            {
                if (value == _moveoutState) return;
                _moveoutState = value;
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

        public OrderRestrictionState RecordUnlawfulCommunicationsAllowedState
        {
            get { return _recordUnlawfulCommunicationsAllowedState; }
            set
            {
                if (value == _recordUnlawfulCommunicationsAllowedState) return;
                _recordUnlawfulCommunicationsAllowedState = value;
                OnPropertyChanged();
            }
        }

        public OrderRestrictionState AnimalsSectionState
        {
            get { return _animalsSectionState; }
            set
            {
                if (value == _animalsSectionState) return;
                _animalsSectionState = value;
                OnPropertyChanged();
            }
        }

        public IDVAnimals AnimalsSection
        {
            get { return _animalsSection; }
            set
            {
                if (Equals(value, _animalsSection)) return;
                _animalsSection = value;
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

        public OrderRestrictionState OtherOrdersState
        {
            get { return _otherOrdersState; }
            set
            {
                if (value == _otherOrdersState) return;
                _otherOrdersState = value;
                OnPropertyChanged();
            }
        }

        public string OtherOrdersDescription
        {
            get { return _otherOrdersDescription; }
            set
            {
                if (value == _otherOrdersDescription) return;
                _otherOrdersDescription = value;
                OnPropertyChanged();
            }
        }

        public bool IsOterordersAttached
        {
            get { return _isOterordersAttached; }
            set
            {
                if (value.Equals(_isOterordersAttached)) return;
                _isOterordersAttached = value;
                OnPropertyChanged();
            }
        }

        public OrderRestrictionState PropertyControlState
        {
            get { return _propertyControlState; }
            set
            {
                if (value == _propertyControlState) return;
                _propertyControlState = value;
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

        public OrderRestrictionState DebtPaymentState
        {
            get { return _debtPaymentState; }
            set
            {
                if (value == _debtPaymentState) return;
                _debtPaymentState = value;
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

        public OrderRestrictionState DVPropertyRestraintState
        {
            get { return _dvPropertyRestraintState; }
            set
            {
                if (value == _dvPropertyRestraintState) return;
                _dvPropertyRestraintState = value;
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

        public OrderRestrictionState ChildCustodyAndVisitationState
        {
            get { return _childCustodyAndVisitationState; }
            set
            {
                if (value == _childCustodyAndVisitationState) return;
                _childCustodyAndVisitationState = value;
                OnPropertyChanged();
            }
        }
    }
}