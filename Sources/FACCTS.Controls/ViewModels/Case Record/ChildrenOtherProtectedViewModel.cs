﻿using Caliburn.Micro;
using Faccts.Model.Entities;
using FACCTS.Controls.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using FACCTS.Services;
using FACCTS.Services.Dialog;

namespace FACCTS.Controls.ViewModels
{
    [Export(typeof(ChildrenOtherProtectedViewModel))]
    public partial class ChildrenOtherProtectedViewModel : ViewModelBase, IHandle<CurrentCourtCaseChangedEvent>
    {
        private IEventAggregator _eventAggregator;
        private IDialogService _dialogService;

        [ImportingConstructor]
        public ChildrenOtherProtectedViewModel(IEventAggregator eventAggregator,
            IDialogService dialogService
            ) : base()
        {
            _eventAggregator = eventAggregator;
            _dialogService = dialogService;
            _eventAggregator.Subscribe(this);
            this.WhenAny(x => x.CurrentCourtCase, x => x.Value)
                .Subscribe(x =>
                {
                    this.NotifyOfPropertyChange(() => CaseRecord);
                });
            this.DisplayName = "Children - Other Protected";
        }

        public void Handle(CurrentCourtCaseChangedEvent message)
        {
            this.CurrentCourtCase = message.CourtCase;
        }

        public CaseRecord CaseRecord
        {
            get
            {
                if (CurrentCourtCase == null || CurrentCourtCase.CaseRecord == null)
                    return null;
                return CurrentCourtCase.CaseRecord;
            }
        }

        private List<EnumDescript<FACCTS.Server.Model.Enums.Relationship>> _relationShips;
        public List<EnumDescript<FACCTS.Server.Model.Enums.Relationship>> Relationships
        {
            get
            {
                if (_relationShips == null)
                {
                    _relationShips = Enum.GetValues(typeof(FACCTS.Server.Model.Enums.Relationship))
                        .Cast<FACCTS.Server.Model.Enums.Relationship>()
                        .Select(x => new EnumDescript<FACCTS.Server.Model.Enums.Relationship>(x))
                        .ToList();
                }
                return _relationShips;
            }
        }

        public void AddChild()
        {
            var newChild = new Children()
            {
                FirstName = "First Name",
                Sex = DataContainer.Sexes.FirstOrDefault(),
            };
            CaseRecord.Children.Add(newChild);
        }

        public void RemoveChild(Children child)
        {
            if (_dialogService.MessageBox("Do you really want to delete the child from the Court Case record?", "Deletion of the Child", System.Windows.MessageBoxButton.YesNo) == System.Windows.MessageBoxResult.Yes)
            {
                CaseRecord.Children.Remove(child);
            }
        }
    }
}
