using System;
using System.ComponentModel.Composition;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace FACCTS.Server.Model.DataModel
{
    [Export]
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("name=FACCTS_DBEntities")
        {
        }

        public DatabaseContext(DbConnection conn) : base(conn, true)
        {

        }

        public DatabaseContext(IDatabaseInitializer<DatabaseContext> initializer)
        {
            Database.SetInitializer(initializer);
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public static Func<DatabaseContext> FactoryMethod { get; set; }

        public static DatabaseContext Get()
        {
            if (FactoryMethod != null) return FactoryMethod();

            return new DatabaseContext();
        }


        public DbSet<CourtCaseStatus> CourtCaseStatuses { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<EyesColor> EyesColor { get; set; }
        public DbSet<HairColor> HairColor { get; set; }
        public DbSet<ParticipantRole> ParticipantRoles { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Sex> Sex { get; set; }
    }
}
