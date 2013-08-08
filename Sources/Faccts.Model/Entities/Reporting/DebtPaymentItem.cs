using System;
using FACCTS.Server.Model.Enums;
using FACCTS.Server.Model.OrderModels;

namespace Faccts.Model.Entities.Reporting
{
    public class DebtPaymentItem : ReactiveBase, IDebtPaymentItem
    {
        private string _name;
        private DateTime _paymentDate;
        private ParticipantRole _paymentFor;
        private decimal _amount;

        public DebtPaymentItem(IDebtPaymentItem debtPaymentItem)
        {
            Name = debtPaymentItem.Name;
            PaymentDate = debtPaymentItem.PaymentDate;
            PaymentFor = debtPaymentItem.PaymentFor;
            Amount = debtPaymentItem.Amount;
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (value == _name) return;
                _name = value;
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

        public DateTime PaymentDate
        {
            get { return _paymentDate; }
            set
            {
                if (value.Equals(_paymentDate)) return;
                _paymentDate = value;
                OnPropertyChanged();
            }
        }

        public ParticipantRole PaymentFor
        {
            get { return _paymentFor; }
            set
            {
                if (value == _paymentFor) return;
                _paymentFor = value;
                OnPropertyChanged();
            }
        }
    }
}