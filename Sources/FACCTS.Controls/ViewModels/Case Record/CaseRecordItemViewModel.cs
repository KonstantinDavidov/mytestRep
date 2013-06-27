using Caliburn.Micro;
using FACCTS.Controls.Events;
using FACCTS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using Faccts.Model.Entities;

namespace FACCTS.Controls.ViewModels
{
    public class CaseRecordItemViewModel : ViewModelBase, IHandle<CurrentCourtCaseChangedEvent>
    {
        private IEventAggregator _eventAggregator;

        public CaseRecordItemViewModel(IEventAggregator eventAggregator) : base()
        {
            if (eventAggregator == null)
            {
                throw new ArgumentNullException("eventAggregator");
            }
            _eventAggregator = eventAggregator;
            this.WhenAny(x => x.CurrentCourtCase, x => x.Value)
                .Subscribe(x =>
                {
                    this.NotifyOfPropertyChange(() => CaseRecord);
                });
            Subscribe();
        }

        public CaseRecordItemViewModel() : this(
            ServiceLocatorContainer.Locator.GetInstance<IEventAggregator>()
            )
        {

        }

        protected virtual IEventAggregator EventAggregator
        {
            get
            {
                return _eventAggregator;
            }
        }

        protected virtual void Subscribe()
        {
            EventAggregator.Subscribe(this);
        }

        public virtual void Handle(CurrentCourtCaseChangedEvent message)
        {
            CurrentCourtCase = message.CourtCase;
        }

        private Faccts.Model.Entities.CourtCase _currentCourtCase;
        public Faccts.Model.Entities.CourtCase CurrentCourtCase
        {
            get { return _currentCourtCase; }
            set
            {
                if (_currentCourtCase != value)
                {
                    this.RaiseAndSetIfChanged(ref _currentCourtCase, value);
                }
            }
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
