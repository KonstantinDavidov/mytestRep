using System;
using FACCTS.Server.Model.OrderModels;

namespace Faccts.Model.Entities.Reporting
{
    public class ChildVisitation : ReactiveBase, IChildVisitation
    {
        private IVisitationSchedule _visitationSchedule;
        private string _visitationGrantedOtherParentDescription;
        private CustodyParent _visitationGrantedParent;
        private string _mediationDescription;
        private bool _isPartiesMustGoToMediation;
        private DateTime _attachedDocumentDate;
        private int _attachedDocumentPagesCount;
        private bool _isAttachedDocumentAvilable;
        private string _isNoVisitationForParents;
        private string _isEnabled;

        public ChildVisitation()
        {
            VisitationSchedule = new VisitationSchedule();
        }

        public ChildVisitation(IChildVisitation visitation)
        {
            IsEnabled = visitation.IsEnabled;
            IsNoVisitationForParents = visitation.IsNoVisitationForParents;
            IsAttachedDocumentAvilable = visitation.IsAttachedDocumentAvilable;
            AttachedDocumentPagesCount = visitation.AttachedDocumentPagesCount;
            AttachedDocumentDate = visitation.AttachedDocumentDate;
            IsPartiesMustGoToMediation = visitation.IsPartiesMustGoToMediation;
            MediationDescription = visitation.MediationDescription;
            VisitationGrantedParent = visitation.VisitationGrantedParent;
            VisitationGrantedOtherParentDescription = visitation.VisitationGrantedOtherParentDescription;
            VisitationSchedule = new VisitationSchedule(visitation.VisitationSchedule);
        }

        public string IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                if (value == _isEnabled) return;
                _isEnabled = value;
                OnPropertyChanged();
            }
        }

        public string IsNoVisitationForParents
        {
            get { return _isNoVisitationForParents; }
            set
            {
                if (value == _isNoVisitationForParents) return;
                _isNoVisitationForParents = value;
                OnPropertyChanged();
            }
        }

        public bool IsAttachedDocumentAvilable
        {
            get { return _isAttachedDocumentAvilable; }
            set
            {
                if (value.Equals(_isAttachedDocumentAvilable)) return;
                _isAttachedDocumentAvilable = value;
                OnPropertyChanged();
            }
        }

        public int AttachedDocumentPagesCount
        {
            get { return _attachedDocumentPagesCount; }
            set
            {
                if (value == _attachedDocumentPagesCount) return;
                _attachedDocumentPagesCount = value;
                OnPropertyChanged();
            }
        }

        public DateTime AttachedDocumentDate
        {
            get { return _attachedDocumentDate; }
            set
            {
                if (value.Equals(_attachedDocumentDate)) return;
                _attachedDocumentDate = value;
                OnPropertyChanged();
            }
        }

        public bool IsPartiesMustGoToMediation
        {
            get { return _isPartiesMustGoToMediation; }
            set
            {
                if (value.Equals(_isPartiesMustGoToMediation)) return;
                _isPartiesMustGoToMediation = value;
                OnPropertyChanged();
            }
        }

        public string MediationDescription
        {
            get { return _mediationDescription; }
            set
            {
                if (value == _mediationDescription) return;
                _mediationDescription = value;
                OnPropertyChanged();
            }
        }

        public CustodyParent VisitationGrantedParent
        {
            get { return _visitationGrantedParent; }
            set
            {
                if (value == _visitationGrantedParent) return;
                _visitationGrantedParent = value;
                OnPropertyChanged();
            }
        }

        public string VisitationGrantedOtherParentDescription
        {
            get { return _visitationGrantedOtherParentDescription; }
            set
            {
                if (value == _visitationGrantedOtherParentDescription) return;
                _visitationGrantedOtherParentDescription = value;
                OnPropertyChanged();
            }
        }

        public IVisitationSchedule VisitationSchedule
        {
            get { return _visitationSchedule; }
            set
            {
                if (Equals(value, _visitationSchedule)) return;
                _visitationSchedule = value;
                OnPropertyChanged();
            }
        }
    }
}