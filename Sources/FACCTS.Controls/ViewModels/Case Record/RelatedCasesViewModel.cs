using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using Caliburn.Micro;
using FACCTS.Services;
using FACCTS.Controls.Events;
using System.Collections.ObjectModel;
using Faccts.Model.Entities;
using System.Dynamic;
using System.Windows.Data;
using System.Reactive.Linq;

namespace FACCTS.Controls.ViewModels
{
    [Export(typeof(RelatedCasesViewModel))]
    public partial class RelatedCasesViewModel : CaseRecordItemViewModel, IHandle<SelectedCourtCasesChangedEvent>
    {
        private IWindowManager _windowManager;
        private IEventAggregator _eventAggregator; 

        public RelatedCasesViewModel() : base()
        {
            this.WhenAny(x => x.CurrentCourtCase, x => x.Value).Subscribe(x =>
                    {
                        this.CanSeparate = x != null;
                    }
                );
            this.WhenAny(x => x.SelectedCourtCases, x => x.Value)
                .Subscribe(x =>
                {
                    this.CanConsolidate = x != null && x.Count > 1 && !x.Any(cc => cc.HasParentCase);

                });
            this.WhenAny(x => x.RelatedCases, x => x.Value)
                .Subscribe(x =>
                {
                    if (x == null)
                    {
                        this.RelatedCasesCollection.Clear();
                    }
                    else
                    {
                        UpdateRelatedCaseCollection(x.Count);
                        x.CollectionCountChanged.Subscribe(i =>
                        {
                            UpdateRelatedCaseCollection(i);
                        }
                        );
                    }
                });
            
            
        }

        [ImportingConstructor]
        public RelatedCasesViewModel(IWindowManager windowManager
            , IEventAggregator eventAggregator
            ) : this()
        {
            _windowManager = windowManager;
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
            this.DisplayName = "Related Cases";
            
        }

        public void Consolidate()
        {
            _windowManager.ShowDialog(ServiceLocatorContainer.Locator.GetInstance<ConsolidateCasesDialogViewModel>());
        }

        public void Separate()
        {
            var vm = ServiceLocatorContainer.Locator.GetInstance<SeparateCaseDialogViewModel>();
            vm.CurrentCourtCase = this.CurrentCourtCase;
            _windowManager.ShowDialog(vm);
        }

        
        public override void Handle(CurrentCourtCaseChangedEvent message)
        {
            if (this.CurrentCourtCase != null)
            {
                this.CurrentCourtCase.ChildCases.CollectionChanged -= ChildCases_CollectionChanged;
            }
            base.Handle(message);
            if (this.CurrentCourtCase != null)
            {
                this.CurrentCourtCase.ChildCases.CollectionChanged += ChildCases_CollectionChanged;
                this.RelatedCases = this.CurrentCourtCase.ChildCases.CreateDerivedCollection(x =>
                {
                    dynamic o = new ExpandoObject();
                    o.CaseNumber = x.CaseNumber;
                    o.Casetype = "DV";
                    //o.County = x.CaseRecord.CourtCounty.county;
                    o.LeadCase = x.ParentCase.CaseNumber;

                    return (ExpandoObject)o;
                }
                , signalReset: this.WhenAny(x => x.RelatedCasesChangedNotifier, y => y));


            }
        }


        private void UpdateRelatedCaseCollection(int itemsInCollection)
        {
            this.RelatedCasesCollection.Clear();
            if (itemsInCollection == 0)
                return;
            CollectionContainer c = new CollectionContainer()
            {
                Collection = this.RelatedCases,
            };
            this.RelatedCasesCollection.Add(c);
            dynamic cc = new ExpandoObject();
            cc.CaseNumber = this.CurrentCourtCase.CaseNumber;
            cc.Casetype = "DV";
            //o.County = x.CaseRecord.CourtCounty.county;
            cc.LeadCase = this.CurrentCourtCase.CaseNumber;
            this.RelatedCasesCollection.Insert(0, cc);
        }

        private void ChildCases_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action != System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                UpdateRelatedCasesNotifier();
            }
            
        }

        public ReactiveCollection<ExpandoObject> _relatedCases;
        public ReactiveCollection<ExpandoObject> RelatedCases
        {
            get
            {
                return _relatedCases;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _relatedCases, value);
            }
        }

        private CompositeCollection _relatedCasesCollection = new CompositeCollection();
        public CompositeCollection RelatedCasesCollection
        {
            get
            {
                return _relatedCasesCollection;
            }
        }

        private static Random rnd = new Random();
        private void UpdateRelatedCasesNotifier()
        {
            this.RelatedCasesChangedNotifier = rnd.NextDouble();
        }

        public void Handle(SelectedCourtCasesChangedEvent message)
        {
            this.SelectedCourtCases = new ObservableCollection<CourtCase>(message.SelectedCourtCases);
        }
    }
}
