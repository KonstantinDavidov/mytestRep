using FACCTS.Server.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Data.EntityConfigurations
{
    internal class CourtCaseConfiguration : EntityTypeConfiguration<CourtCase>
    {
        public CourtCaseConfiguration()
        {
            ToTable(DbConsts.COURT_CASES_TABLE_NAME, DbConsts.SCHEMA_NAME);

            HasKey(c => c.Id);

            HasMany(c => c.RelatedCases).WithOptional(rc => rc.ParentCase).HasForeignKey(rc => rc.ParentCaseId);
            HasOptional(c => c.Party1).WithMany().HasForeignKey(c => c.Party1Id);
            HasOptional(c => c.Party2).WithMany().HasForeignKey(c => c.Party2Id);
            HasMany(c => c.Children).WithOptional(child => child.CourtCaseForChild).HasForeignKey(child => child.CourtCaseForChildId);
            HasMany(c => c.OtherProtected).WithOptional(op => op.CourtCaseForOtherProtected).HasForeignKey(op => op.CourtCaseForOtherProtectedId);
            HasMany(c => c.Witnesses).WithOptional(w => w.CourtCaseForWitness).HasForeignKey(w => w.CourtCaseForWitnessId);
            HasMany(c => c.Interpreters).WithOptional(i => i.CourtCaseForInterpreter).HasForeignKey(i => i.CourtCaseForInterpreterId);
            HasMany(c => c.CaseHistory).WithRequired(h => h.CourtCase).HasForeignKey(h => h.CourtCaseId);
            HasMany(c => c.CaseNotes).WithRequired(n => n.CourtCase).HasForeignKey(n => n.CourtCaseId);
            HasOptional(c => c.AttorneyForChild).WithMany().HasForeignKey(c => c.AttorneyForChildId);
            HasOptional(c => c.ThirdPartyData).WithMany().HasForeignKey(c => c.ThirdPartyDataId);
            HasMany(c => c.Hearings).WithRequired(h => h.CourtCase).HasForeignKey(h => h.CourtCaseId).WillCascadeOnDelete(true);

            Property(c => c.Id).HasColumnName(DbConsts.ID_COLUMN_NAME);
            Property(c => c.CaseNumber).HasColumnName(DbConsts.COURT_CASE_CASE_NUMBER_COLUMN_NAME).HasMaxLength(20);
            Property(c => c.CourtClerkId).HasColumnName(DbConsts.COURT_CASE_COURT_CLERK_ID_COLUMN_NAME);
            Property(c => c.CCPORStatus).HasColumnName(DbConsts.COURT_CASE_CCPOR_STATUS_COLUMN_NAME);
            Property(c => c.CCPORId).HasColumnName(DbConsts.COURT_CASE_CCPOR_ID_COLUMN_NAME).HasMaxLength(20);
            Property(c => c.ParentCaseId).HasColumnName(DbConsts.COURT_CASE_PARENT_CASE_ID_COLUMN_NAME);
            Property(c => c.Party1Id).HasColumnName(DbConsts.COURT_CASE_PARTY1_ID_COLUMN_NAME);
            Property(c => c.Party2Id).HasColumnName(DbConsts.COURT_CASE_PARTY2_ID_COLUMN_NAME);
            Property(c => c.AttorneyForChildId).HasColumnName(DbConsts.COURT_CASE_ATTORNEY_FOR_CHILD_ID_COLUMN_NAME);
            Property(c => c.ThirdPartyDataId).HasColumnName(DbConsts.COURT_CASE_THIRD_PARTY_DATA_ID_COLUMN_NAME);

            Ignore(c => c.State);
        }
    }
}
