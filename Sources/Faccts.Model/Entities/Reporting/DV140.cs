using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using FACCTS.Server.Model.OrderModels;

namespace Faccts.Model.Entities.Reporting
{
    public class DV140: OrderBase, IDV140
    {
        private IOtherOrders _otherOrders;
        private IExchangeAndRemoval _exchangeAndRemoval;
        private IChildVisitation _childVisitation;
        private ICollection<IChildCustodyItem> _childCustodyItems;

        public DV140()
        {
            ChildCustodyItems = new ObservableCollection<IChildCustodyItem>();
            ChildVisitation = new ChildVisitation();
            ExchangeAndRemoval = new ExchangeAndRemoval();
            OtherOrders = new OtherOrders();
        }

        public DV140(IDV140 order)
        {
            ChildCustodyItems =
                new ObservableCollection<IChildCustodyItem>(order.ChildCustodyItems.Select(i => new ChildCustodyItem(i)));
            ChildVisitation = new ChildVisitation(order.ChildVisitation);
            ExchangeAndRemoval = new ExchangeAndRemoval(order.ExchangeAndRemoval);
            OtherOrders = new OtherOrders(order.OtherOrders);
        }

        public ICollection<IChildCustodyItem> ChildCustodyItems
        {
            get { return _childCustodyItems; }
            set
            {
                if (Equals(value, _childCustodyItems)) return;
                _childCustodyItems = value;
                OnPropertyChanged();
            }
        }

        public IChildVisitation ChildVisitation
        {
            get { return _childVisitation; }
            set
            {
                if (Equals(value, _childVisitation)) return;
                _childVisitation = value;
                OnPropertyChanged();
            }
        }

        public IExchangeAndRemoval ExchangeAndRemoval
        {
            get { return _exchangeAndRemoval; }
            set
            {
                if (Equals(value, _exchangeAndRemoval)) return;
                _exchangeAndRemoval = value;
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
    }
}