using FACCTS.Server.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Data.EntityConfigurations
{
    internal class HearingConfiguration : EntityTypeConfiguration<Hearing>
    {
        public HearingConfiguration()
        {
            ToTable(DbConsts.HEARINGS_TABLE_NAME, DbConsts.SCHEMA_NAME);

            HasKey(h => h.Id);

            HasMany(h => h.CourtOrders).WithRequired(o => o.Hearing).HasForeignKey(o => o.HearingId);
            HasOptional(h => h.Reissue).WithRequired(i => i.ParentHearing);

            Property(h => h.Id).HasColumnName(DbConsts.ID_COLUMN_NAME);
            Property(h => h.HearingDate).HasColumnName(DbConsts.HEARING_HEARING_DATE_COLUMN_NAME);
            Property(h => h.CourtroomId).HasColumnName(DbConsts.HEARING_COURTROOM_ID_COLUMN_NAME);
            Property(h => h.CourtDepartmentId).HasColumnName(DbConsts.HEARING_COURT_DEPARTMENT_ID_COLUMN_NAME);
            Property(h => h.Session).HasColumnName(DbConsts.HEARING_SESSION_COLUMN_NAME);
            Property(h => h.CourtCaseId).HasColumnName(DbConsts.HEARING_COURT_CASE_ID_COLUMN_NAME);

            Ignore(h => h.State);
        }
    }
}
