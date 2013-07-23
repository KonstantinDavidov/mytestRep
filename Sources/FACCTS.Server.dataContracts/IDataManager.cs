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
        IFacctsDictionaryDataRepository<Designation> DesignationRepository { get; }

        //Entities
        IFacctsDataRepository<CourtParty> CourtPartyRepository { get; }
        ICourtMemberRepository CourtMemberRepository { get; }
        IFacctsDataRepository<User> UserRepository { get; }
        IFacctsDataRepository<CourtCase> CourtCaseRepository { get; }
        IFacctsDataRepository<Role> FacctsRoleRepository { get; }

        IFacctsDataRepository<CourtCounty> CourtCountyRepository { get; }
        IFacctsDataRepository<CourtDepartment> CourtDepartmentRepository { get; }
        IFacctsDataRepository<CaseHistory> CaseHistoryRepository { get; }
<<<<<<< HEAD
        IFacctsDataRepository<CourtCaseOrder> CourtCaseOrdersRepository { get; }
        
=======
>>>>>>> e54be96ad60972456dc6551e11eb5064e4c49607
        IFacctsDictionaryDataRepository<FACCTSConfiguration> FACCTSConfigurationRepository { get; }
        IFacctsDataRepository<Courtroom> CourtroomRepository { get; }
        IFacctsDictionaryDataRepository<Race> RaceRepository { get; }
        IFacctsDataRepository<Hearing> HearingRepository { get; }

        IFacctsDataRepository<ManualIntegrationTask> ManualIntegrationTaskRepository { get; }
        IFacctsDataRepository<ScheduledIntegrationTask> ScheduledIntegrationTaskRepository { get; }
        IFacctsDataRepository<CourtPartyAttorneyData> CourtPartyAttorneyDataRepository { get; }
        IFacctsDataRepository<Attorney> AttorneyRepository { get; }
        IFacctsDataRepository<CaseNote> CaseNoteRepository { get; }
        IFacctsDataRepository<Witness> WitnessRepository { get; }
        IFacctsDataRepository<Interpreter> InterpreterRepository { get; }
        IFacctsDataRepository<Child> ChildrenRepository { get; }

        // Save pending changes to the data store.
        void Commit();

    }
}
