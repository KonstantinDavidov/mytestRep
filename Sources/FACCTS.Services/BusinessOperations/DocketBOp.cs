using Faccts.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Services.BusinessOperations
{
    public class DocketBOp : StrategyBase
    {
        private Hearings _hearing;
        public DocketBOp(Hearings hearing) : base()
        {
            if (hearing == null)
            {
                throw new ArgumentNullException("hearing");
            }
            _hearing = hearing;
        }

        public override Faccts.Model.Entities.CourtCase Execute(Faccts.Model.Entities.CourtCase courtCase)
        {
            if (courtCase == null)
            {
                throw new ArgumentNullException("courtCase");
            }
            DataContainer.Hearings.Add(_hearing);
            courtCase.AssignNewHearing(_hearing);
            courtCase.LastAction = Server.Model.Enums.CourtAction.Docketed;
            return courtCase;
        }

    }
}
