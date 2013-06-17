using Faccts.Model.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace FACCTS.Services.Data
{
    [Export(typeof(IDataContainer))]
    public class DataContainer : IDataContainer
    {
        public DataContainer()
        {
            //SearchCourtCases();
        }

        private SearchCriteria _searchCriteria = new SearchCriteria();
        public SearchCriteria SearchCriteria
        {
            get
            {
                return _searchCriteria;
            }
        }

        private TrackableCollection<CourtCase> _courtCases;
        public TrackableCollection<CourtCase> CourtCases
        {
            get
            {
                return _courtCases;
            }
            private set
            {
                _courtCases = value;
            }
        }

        private ObjectChangeTracker _changeTracker;
        public ObjectChangeTracker ChangeTracker
        {
            get
            {
                if (_changeTracker == null)
                {
                    _changeTracker = new ObjectChangeTracker();
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
                return _changeTracker;
            }
            set
            {
                if (_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging -= HandleObjectStateChanging;
                }
                _changeTracker = value;
                if (_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
            }
        }

        private void HandleObjectStateChanging(object sender, ObjectStateChangingEventArgs e)
        {
            //TODO: implement this when needed
        }

        public void SearchCourtCases()
        {
            ChangeTracker.ChangeTrackingEnabled = false;
            try
            {
                CourtCases = new TrackableCollection<CourtCase>(FACCTS.Services.Data.CourtCases.GetAll());
            }
            finally
            {
                ChangeTracker.ChangeTrackingEnabled = true;   
            }
        }
    }

    public class SearchCriteria
    {
        public SearchCriteria()
        {

        }

        public string CaseNumber { get; set; }
        public string CCPOR_ID { get; set; }
        public DateTime? FirstActivityEndDate { get; set; }
        public DateTime? FirstActivityStartDate { get; set; }
        public DateTime? LastActivityEndDate { get; set; }
        public DateTime? LastActivityStartDate { get; set; }
        public string Party1FirstName { get; set; }
        public string Party1LastName { get; set; }
        public string Party1MiddleName { get; set; }
        public string Party2FirstName { get; set; }
        public string Party2LastName { get; set; }
        public string Party2MiddleName { get; set; }
        public FACCTS.Server.Model.Enums.CaseStatus CaseStatus { get; set; }
        public Faccts.Model.Entities.User CourtClerk { get; set; }

        public Server.Model.Enums.CCPORStatus CCPORStatus { get; set; }
    }

   
}
