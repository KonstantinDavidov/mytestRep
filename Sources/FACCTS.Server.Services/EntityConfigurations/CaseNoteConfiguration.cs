using FACCTS.Server.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Data.EntityConfigurations
{
    internal class CaseNoteConfiguration : EntityTypeConfiguration<CaseNote>
    {
        public CaseNoteConfiguration()
        {
            ToTable(DbConsts.CASE_NOTES_TABLE_NAME, DbConsts.SCHEMA_NAME);

            HasKey(n => n.Id);

            Property(n => n.Id).HasColumnName(DbConsts.ID_COLUMN_NAME);
            Property(n => n.Status).HasColumnName(DbConsts.CASE_NOTE_STATUS_COLUMN_NAME);
            Property(n => n.Text).HasColumnName(DbConsts.CASE_NOTE_TEXT_COLUMN_NAME);
            Property(n => n.CourtCaseId).HasColumnName(DbConsts.CASE_NOTE_COURT_CASE_ID_COLUMN_NAME);
            Property(n => n.AuthorId).HasColumnName(DbConsts.CASE_NOTE_AUTHOR_ID_COLUMN_NAME);

            Ignore(n => n.State);
        }
    }
}
