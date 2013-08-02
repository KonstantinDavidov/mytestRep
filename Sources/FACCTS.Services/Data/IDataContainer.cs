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
        TrackableCollection<CourtCaseHeading> CourtCaseHeadings { get; }
        SearchCriteria SearchCriteria { get; }
        FACCTSConfiguration FacctsConfiguration { get; }
        List<CourtDepartment> AvailableDepartments { get; }
        List<Courtrooms> AvailableCourtrooms { get; }
        List<EnumDescript<Gender>> Sexes { get; }
        List<HairColor> HairColors { get; }
        List<EyesColor> EyesColors { get; }
        List<Race> Races { get; }
        List<EnumDescript<USAState>> StateList { get; }
        List<EnumDescript<FACCTSEntity>> EntityTypeList { get; }
        List<EnumDescript<ParticipantRole>> ParticipantRoles { get; }
        List<EnumDescript<FACCTS.Server.Model.Enums.Relationship>> Relationships { get; }
        List<EnumDescript<FACCTS.Server.Model.Enums.Designation>> Designations { get; }
        List<EnumDescript<AddressType>> AddressTypes { get; }
        CourtCase CurrentCourtCase { get; }
        void UpdateBySelection(Faccts.Model.Entities.CourtCaseHeading selectedItem);

        void SearchCourtCases(bool reset = false);
        void UpdateDictionaries();
        TrackableCollection<Hearings> Hearings { get; }
        CourtCase SaveData(CourtCase courtCaseToSave);
    }
}
