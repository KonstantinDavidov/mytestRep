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
        public virtual Faccts.Model.Entities.CourtCase CurrentCourtCase
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

        protected override void SaveData()
        {
            base.SaveData();
            if (CurrentCourtCase == null)
                return;
            if (CurrentCourtCase.ChangeTracker.State == ObjectState.Unchanged)
                return;
            if (!CurrentCourtCase.IsDirty)
                return;
            switch (CurrentCourtCase.ChangeTracker.State)
            {
                case ObjectState.Added:

                    break;
                case ObjectState.Deleted:

                    break;
                case ObjectState.Modified:

                    break;
            }
        }
    }
}
