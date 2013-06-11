﻿using FACCTS.Server.Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Model.DataModel
{
    public partial class CourtCase
    {
        [NotMapped]
        public CaseStatus CaseStatus
        {
            get
            {
                return CaseHistoryEventToStatus(this.CaseRecord.CaseHistory.Where(x => x.Date <= DateTime.Now).First().CaseHistoryEvent);
            }
        }

        [NotMapped]
        public DateTime? FirstActivity
        {
            get
            {
                return this.CaseRecord.CaseHistory.Select(X => X.Date).Min();
            }
        }

        public DateTime? LastActivity 
        {
            get
            {
                return this.CaseRecord.CaseHistory.Select(X => X.Date).Max();
            } 
        }

        private static CaseStatus CaseHistoryEventToStatus(CaseHistoryEvent chEvent)
        {
            return (CaseStatus)(int)chEvent;
        }
    }
}