using FACCTS.Server.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Data.EntityConfigurations
{
    internal class CaseHistoryConfiguration : EntityTypeConfiguration<CaseHistory>
    {
        public CaseHistoryConfiguration()
        {
            ToTable(DbConsts.CASE_HISTORY_TABLE_NAME, DbConsts.SCHEMA_NAME);

            HasKey(h => h.Id);

            HasOptional(h => h.CourtClerk).WithMany().HasForeignKey(h => h.CourtClerkId);
            HasOptional(h => h.MergeCase).WithMany().HasForeignKey(h => h.MergeCaseId);
            HasOptional(h => h.Hearing).WithMany().HasForeignKey(h => h.HearingId);

            Property(c => c.Date).HasColumnName(DbConsts.CASE_HISTORY_DATE_COLUMN_NAME);
            Property(c => c.CaseHistoryEvent).HasColumnName(DbConsts.CASE_HISTORY_CASE_HISTORY_EVENT_COLUMN_NAME);
            Property(c => c.CourtClerkId).HasColumnName(DbConsts.CASE_HISTORY_COURT_CLERK_ID_COLUMN_NAME);
            Property(c => c.CCPOR_ID).HasColumnName(DbConsts.CASE_HISTORY_CCPOR_ID_COLUMN_NAME).HasMaxLength(30);
            Property(c => c.CourtCaseId).HasColumnName(DbConsts.CASE_HISTORY_COURT_CASE_ID_COLUMN_NAME);
            Property(c => c.MergeCaseId).HasColumnName(DbConsts.CASE_HISTORY_MERGE_CASE_ID_COLUMN_NAME);
            Property(c => c.HearingId).HasColumnName(DbConsts.CASE_HISTORY_HEARING_ID_COLUMN_NAME);

            Ignore(c => c.State);
        }
    }
}
