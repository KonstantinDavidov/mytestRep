using Faccts.Model.Entities;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Controls.ViewModels
{
    public class CourtCaseHeadingViewModel : ReactiveObject
    {
        public CourtCaseHeadingViewModel(CourtCaseHeading heading)
            : base()
        {
            if (heading == null)
            {
                throw new ArgumentNullException("heading");
            }
            Heading = heading;
            if (Heading is CourtCaseHistoryHeading)
            {
                this.IsVisible = false;
            }
            else
            {
                this.IsVisible = true;
            }
            this.WhenAny(x => x.IsExpanded, x => x.Value)
                .Subscribe(x =>
                {
                    this.Childs.Aggregate(0, (index, item) =>
                        {
                            item.IsVisible = x;
                            return ++index;
                        }
                        );
                }
                );
        }

        private bool _isVisible;
        public bool IsVisible
        {
            get
            {
                return _isVisible;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _isVisible, value);
            }
        }

        private bool _isExpanded;
        public bool IsExpanded
        {
            get
            {
                return _isExpanded;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _isExpanded, value);
            }
        }

        public int Level
        {
            get
            {
                if (Heading is CourtCaseHistoryHeading)
                {
                    return 1;
                }
                return 0;
            }
        }

        public bool HasChilds
        {
            get
            {
                if (Heading is CourtCaseHistoryHeading)
                {
                    return false;
                }
                return true;
            }
        }

        private ReactiveCollection<CourtCaseHeadingViewModel> _childs;
        public ReactiveCollection<CourtCaseHeadingViewModel> Childs
        {
            get
            {
                if (Heading == null)
                {
                    return null;
                }
                if (_childs == null)
                {
                    _childs = Heading.CourtCaseHistoryHeadings.CreateDerivedCollection(x => new CourtCaseHeadingViewModel(x));
                }
                return _childs;
            }
        }

        public CourtCaseHeading Heading { get; private set; }

        public IEnumerable<CourtCaseHeadingViewModel> GetAll()
        {
            yield return this;
            if (HasChilds)
            {
                foreach (var item in Childs)
                {
                    yield return item;
                }
            }
        }

        private static readonly Random random = new Random();

        internal void UpdateChilds(IEnumerable<CourtCaseHistoryHeading> childHeadings)
        {
            childHeadings.Aggregate(Heading.CourtCaseHistoryHeadings, (collection, item) =>
                {
                    collection.Add(item);
                    return collection;
                }
                );
            ChildsChangedNotifier = random.NextDouble();
        }

        private double _childsChangedNotifier;
        public double ChildsChangedNotifier
        {
            get
            {
                return _childsChangedNotifier;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref _childsChangedNotifier, value);
            }
        }

    }
}
