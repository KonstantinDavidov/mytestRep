using System;
namespace FACCTS.Server.Model.Interfaces
{
    public interface ICourtCaseSearchCriteria
    {
        string CaseNumber { get; set; }
        FACCTS.Server.Model.Enums.CaseStatus? CaseStatus { get; set; }
        string CCPOR_ID { get; set; }
        long? CourtClerkId { get; set; }
        DateTime? FirstHearingEnd { get; set; }
        DateTime? FirstHearingStart { get; set; }
        DateTime? LastHearingEnd { get; set; }
        DateTime? LastHearingStart { get; set; }
        string Party1FirstName { get; set; }
        string Party1LastName { get; set; }
        string Party1MiddleName { get; set; }
        string Party2FirstName { get; set; }
        string Party2LastName { get; set; }
        string Party2MiddleName { get; set; }
    }
}
