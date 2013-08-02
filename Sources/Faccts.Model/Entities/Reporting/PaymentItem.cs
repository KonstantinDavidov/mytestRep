using System;
using FACCTS.Server.Model.OrderModels;

namespace Faccts.Model.Entities.Reporting
{
    public class PaymentItem : ReactiveBase, IPaymentItem
    {
        private decimal _amount;
        private bool _isAttorneyFee;
        private string _paymentDescription;
        private DateTime _paymentDueDate;
        private string _paymentFor;

        public PaymentItem()
        {
        }

        public PaymentItem(IPaymentItem item)
        {
            PaymentDescription = item.PaymentDescription;
            IsAttorneyFee = item.IsAttorneyFee;
            PaymentFor = item.PaymentFor;
            Amount = item.Amount;
            PaymentDueDate = item.PaymentDueDate;
        }

        public string PaymentDescription
        {
            get { return _paymentDescription; }
            set
            {
                if (value == _paymentDescription) return;
                _paymentDescription = value;
                OnPropertyChanged();
            }
        }

        public bool IsAttorneyFee
        {
            get { return _isAttorneyFee; }
            set
            {
                if (value.Equals(_isAttorneyFee)) return;
                _isAttorneyFee = value;
                OnPropertyChanged();
            }
        }

        public string PaymentFor
        {
            get { return _paymentFor; }
            set
            {
                if (value == _paymentFor) return;
                _paymentFor = value;
                OnPropertyChanged();
            }
        }

        public decimal Amount
        {
            get { return _amount; }
            set
            {
                if (value == _amount) return;
                _amount = value;
                OnPropertyChanged();
            }
        }

        public DateTime PaymentDueDate
        {
            get { return _paymentDueDate; }
            set
            {
                if (value.Equals(_paymentDueDate)) return;
                _paymentDueDate = value;
                OnPropertyChanged();
            }
        }
    }
}