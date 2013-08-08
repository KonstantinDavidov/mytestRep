using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FACCTS.Server.Models
{
    public class CourtCaseCreationRequest
    {
        public string CaseNumber { get; set; }
        public long CourtClerkId { get; set; }
    }
}