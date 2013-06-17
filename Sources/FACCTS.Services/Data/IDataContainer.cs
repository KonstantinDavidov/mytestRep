using Faccts.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Services.Data
{
    public interface IDataContainer
    {
        TrackableCollection<CourtCase> CourtCases { get; }

        void SearchCourtCases();
    }
}
