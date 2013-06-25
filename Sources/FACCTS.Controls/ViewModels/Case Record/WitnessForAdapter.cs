using Faccts.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace FACCTS.Controls.ViewModels
{
    public class WitnessForAdapter : ViewModelBase
    {
        private bool _isParty1;
        public WitnessForAdapter(CourtParty courtParty, bool isParty1 = true)
            : base()
        {
            if (courtParty == null)
            {
                throw new ArgumentNullException("courtParty");
            }
            UnderlyingObject = courtParty;
            UnderlyingObject.WhenAny(
                            y => y.FirstName,
                            y => y.MiddleName,
                            y => y.LastName,
                            (x1, x2, x3) => new
                            {
                                FirstName = x1,
                                MiddleName = x2,
                                LastName = x3,
                            }
                            )
                            .Subscribe(y =>
                            {
                                if (string.IsNullOrWhiteSpace(UnderlyingObject.FullName))
                                {
                                    DisplayName = string.Format("Witness for: {0}", _isParty1 ? "Party 1" : "Party 2");
                                }
                                else
                                {
                                    DisplayName = string.Format("Witness for: {0}", UnderlyingObject.FullName);
                                }
                            }
                            );
            _isParty1 = isParty1;
        }

        public CourtParty UnderlyingObject
        {
            get;
            private set;
        }

        public override string DisplayName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(UnderlyingObject.FullName))
                {
                    base.DisplayName = string.Format("Witness for: {0}", _isParty1 ? "Party 1" : "Party 2");
                }
                return base.DisplayName;
            }
            set
            {
                base.DisplayName = value;
            }
        }

        public override string ToString()
        {
            return this.DisplayName;
        }
    }
}
