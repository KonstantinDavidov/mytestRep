using FACCTS.Server.Model.DataModel;
using FACCTS.Server.Model.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACCTS.Server.Data.EntityConfigurations
{
    internal class CourtPartyConfiguration: EntityTypeConfiguration<CourtParty>
    {
        public CourtPartyConfiguration()
        {
            //Map(m => m.Requires(DbConsts.PERSON_DISCRIMINATOR_COLUMN).HasValue((int)PersonType.CourtParty));

            Property(p => p.MiddleName).HasColumnName(DbConsts.COURT_PARTY_MIDDLE_NAME_COLUMN_NAME).HasMaxLength(255);
            Property(p => p.Description).HasColumnName(DbConsts.COURT_PARTY_DESCRIPTION_COLUMN_NAME);
            Property(p => p.ParticipantRole).HasColumnName(DbConsts.COURT_PARTY_PARTICIPANT_ROLE_COLUMN_NAME);
            Property(p => p.Designation).HasColumnName(DbConsts.COURT_PARTY_DESIGNATION_COLUMN_NAME);
            Property(p => p.ParentRole).HasColumnName(DbConsts.COURT_PARTY_PARENT_ROLE_COLUMN_NAME).HasMaxLength(50);
            Property(p => p.HairColorId).HasColumnName(DbConsts.COURT_PARTY_HAIR_COLOR_ID_COLUMN_NAME);
            Property(p => p.EyesColorId).HasColumnName(DbConsts.COURT_PARTY_EYES_CLOR_ID_COLUMN_NAME);
            Property(p => p.RaceId).HasColumnName(DbConsts.COURT_PARTY_RACE_ID_COLUMN_NAME);
            Property(p => p.RelationToOtherParty).HasColumnName(DbConsts.COURT_PARTY_RELATION_TO_OTHER_PARTY_COLUMN_NAME);
            Property(p => p.Weight).HasColumnName(DbConsts.COURT_PARTY_WEIGHT_COLUMN_NAME);
            Property(p => p.HeightFt).HasColumnName(DbConsts.COURT_PARTY_HEIGHT_FT_COLUMN_NAME);
            Property(p => p.HeightIns).HasColumnName(DbConsts.COURT_PARTY_HEIGHT_INS_COLUMN_NAME);
            Property(p => p.AttorneyId).HasColumnName(DbConsts.COURT_PARTY_ATTORNEY_ID_COLUMN_NAME);
            Property(p => p.IsProPer).HasColumnName(DbConsts.COURT_PARTY_IS_PROPER_COLUMN_NAME);

            HasMany(p => p.Witnesses).WithOptional(w => w.WitnessFor).HasForeignKey(w => w.CourtPartyId);
            HasOptional(p => p.Interpreter).WithMany().HasForeignKey(p => p.InterpreterId);
            HasOptional(p => p.HairColor).WithMany().HasForeignKey(p => p.HairColorId);
            HasOptional(p => p.EyesColor).WithMany().HasForeignKey(p => p.EyesColorId);
            HasOptional(p => p.Race).WithMany().HasForeignKey(p => p.RaceId);
            HasOptional(p => p.Attorney).WithMany().HasForeignKey(p => p.AttorneyId);
        }
    }
}
