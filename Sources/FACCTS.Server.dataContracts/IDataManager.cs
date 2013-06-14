using FACCTS.Server.Model.DataModel;
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
        IFacctsDataRepository<CourtCase> CourtCaseRepository { get; }
        IFacctsDataRepository<Role> FacctsRoleRepository { get; }

        //Entities
        IFacctsDataRepository<CourtParty> CourtPartyRepository { get; }
        ICourtMemberRepository CourtMemberRepository { get; }
        IFacctsDataRepository<User> UserRepository { get; }

        IFacctsDataRepository<CourtCounty> CourtCountyRepository { get; }
        IFacctsDataRepository<CourtDepartment> CourtDepartmentRepository { get; }

        // Save pending changes to the data store.
        void Commit();

    }
}
