using Faccts.Model.Entities;
using FACCTS.Server.Model.Enums;
using ReactiveUI;
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
        List<EnumDescript<Gender>> Sexes { get; }
        List<HairColor> HairColors { get; }
        List<EyesColor> EyesColors { get; }
        List<Race> Races { get; }
        List<Designation> Designations { get; }
        //List<ParticipantRole> ParticipantRoles { get; }

        void SearchCourtCases(bool reset = false);
        void UpdateDictionaries();
        TrackableCollection<CourtDocketRecord> CourtDocketRecords { get; }
    }
}
