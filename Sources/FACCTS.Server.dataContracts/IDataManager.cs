using FACCTS.Server.Model.DataModel;
using FACCTS.Server.Model.DataModel.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.DataContracts
{
    public interface IDataManager : IDisposable
    {
        //Dictionaries
        IFacctsDictionaryDataRepository<HairColor> HairColorRepository { get; }
        IFacctsDictionaryDataRepository<EyesColor> EyesColorRepository { get; }
        IFacctsDictionaryDataRepository<Sex> SexRepository { get; }
        IFacctsDictionaryDataRepository<Designation> DesignationRepository { get; }

        //Entities
        IFacctsDataRepository<CourtParty> CourtPartyRepository { get; }
        ICourtMemberRepository CourtMemberRepository { get; }
        IFacctsDataRepository<User> UserRepository { get; }
        IFacctsDataRepository<CourtCase> CourtCaseRepository { get; }
        IFacctsDataRepository<Role> FacctsRoleRepository { get; }

        IFacctsDataRepository<CourtCounty> CourtCountyRepository { get; }
        IFacctsDataRepository<CourtDepartment> CourtDepartmentRepository { get; }
        IFacctsDataRepository<CaseRecord> CaseRecordRepository { get; }
        IFacctsDataRepository<CaseHistory> CaseHistoryRepository { get; }
        IFacctsDictionaryDataRepository<FACCTSConfiguration> FACCTSConfigurationRepository { get; }
        IFacctsDataRepository<Courtroom> CourtroomRepository { get; }
        IFacctsDictionaryDataRepository<Race> RaceRepository { get; }

        IFacctsDataRepository<ManualIntegrationTask> ManualIntegrationTaskRepository { get; }
        IFacctsDataRepository<ScheduledIntegrationTask> ScheduledIntegrationTaskRepository { get; }

        // Save pending changes to the data store.
        void Commit();

    }
}
