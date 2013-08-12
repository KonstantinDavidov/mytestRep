using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Faccts.Model.Entities.Reporting;
using FACCTS.Server.Model.Enums;

namespace FACCTS.Controls.ViewModels
{
    public class DV110PropertyAndAttorneysFeeViewModel : CourtOrderBaseViewModel<DV110>
    {
        public DV110PropertyAndAttorneysFeeViewModel() : base()
        {
            this.DisplayName = "DV110 Temporary Restraining Order - Property and Attorney's Fees";
            OrderType=CourtOrdersTypes.DV110;
        }

        public void AddPropertyControlItem()
        {
            Order.PropertyControlItems.Add(new DataItem());
        }

        public void RemovePropertyControlItem(DataItem item)
        {
            Order.PropertyControlItems.Remove(item);
        }

        public void AddPaymentItem()
        {
            Order.DebtPaymentItems.Add(new DebtPaymentItem());
        }

        public void RemovePaymentItem(DebtPaymentItem item)
        {
            Order.DebtPaymentItems.Remove(item);
        }
    }
}
