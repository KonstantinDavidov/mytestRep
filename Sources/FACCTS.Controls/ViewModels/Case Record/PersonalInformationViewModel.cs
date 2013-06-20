using Caliburn.Micro;
using Faccts.Model.Entities;
using FACCTS.Controls.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace FACCTS.Controls.ViewModels
{
    [Export(typeof(PersonalInformationViewModel))]
    public partial class PersonalInformationViewModel : ViewModelBase, IHandle<CurrentCourtCaseChangedEvent>
    {
        private IEventAggregator _eventAggregator;

        public PersonalInformationViewModel() : base()
        {
            this.WhenAny(x => x.CurrentCourtCase, x => x.Value)
                .Subscribe(x =>
                {
                    this.NotifyOfPropertyChange(() => CaseRecord);
                });
        }

        [ImportingConstructor]
        public PersonalInformationViewModel(IEventAggregator eventAggregator) : this()
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
            this.DisplayName = "Personal Information";
            
        }

        public void Handle(CurrentCourtCaseChangedEvent message)
        {
            this.CurrentCourtCase = message.CourtCase;
        }

        public CaseRecord CaseRecord
        {
            get
            {
                if (this.CurrentCourtCase != null)
                {
                    return this.CurrentCourtCase.CaseRecord;
                }
                return null;
            }
        }
    }
}
