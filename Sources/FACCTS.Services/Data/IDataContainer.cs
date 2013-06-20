using Faccts.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Services.Data
{
    public interface IDataContainer : INotifyPropertyChanged
    {
        TrackableCollection<CourtCase> CourtCases { get; }
        SearchCriteria SearchCriteria { get; }
        FACCTSConfiguration FacctsConfiguration { get; }
        List<CourtDepartmenets> AvailableDepartments { get; }
        List<Courtrooms> AvailableCourtrooms { get; }

        void SearchCourtCases(bool reset = false);
    }
}
