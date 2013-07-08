using FACCTS.Server.Common;
using FACCTS.Server.Data.EntityConfigurations;
using FACCTS.Server.DataContracts;
using FACCTS.Server.Model.DataModel;
using FACCTS.Server.Model.DataModel.Configuration;
using System;
using System.ComponentModel.Composition;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace FACCTS.Server.Data
{
    [Export(typeof(IDatabaseContext))]
    public partial class DatabaseContext : DbContext, IDatabaseContext
    {

        public DatabaseContext()
            : base("name=FACCTS_DB")
        {
            Configuration.LazyLoadingEnabled = true;
        }

        public DatabaseContext(DbConnection dbConn) : base(dbConn, true)
        {
            Configuration.LazyLoadingEnabled = true;
        }

        public DatabaseContext(IDatabaseInitializer<DatabaseContext> initializer)
        {
            Configuration.LazyLoadingEnabled = true;
            Database.SetInitializer<DatabaseContext>(initializer);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //Role => Permissions m-to-m
            modelBuilder.Entity<Role>()
                .HasMany(r => r.Permissions)
                .WithMany(p => p.Roles)
                .Map(m =>
                   {
                       m.MapLeftKey("RoleId");
                       m.MapRightKey("Id");
                       m.ToTable("RolePermission");
                   });

            modelBuilder.Configurations.Add(new ManualIntegrationTaskConfiguration());
            modelBuilder.Configurations.Add(new ScheduledIntegrationTaskConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public static Func<DatabaseContext> FactoryMethod { get; set; }

        public static DatabaseContext Get()
        {
            if (FactoryMethod != null) return FactoryMethod();

            return new DatabaseContext();
        }

        #region Dictionary tables
        
        public DbSet<Designation> Designations { get; set; }
        public DbSet<EyesColor> EyesColor { get; set; }
        public DbSet<HairColor> HairColor { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Sex> Sex { get; set; }
        public DbSet<CourtLocation> CourtLocations { get; set; }
        public DbSet<FormField> FormFields { get; set; }
        public DbSet<CourtCounty> CourtCounties { get; set; }
        public DbSet<Courtroom> Courtrooms { get; set; }

        #endregion

        #region Identity provider entities
        public DbSet<GlobalConfiguration> GlobalConfiguration { get; set; }
        public DbSet<WSFederationConfiguration> WSFederation { get; set; }
        public DbSet<KeyMaterialConfiguration> Keys { get; set; }
        public DbSet<WSTrustConfiguration> WSTrust { get; set; }
        public DbSet<FederationMetadataConfiguration> FederationMetadata { get; set; }
        public DbSet<OAuth2Configuration> OAuth2 { get; set; }
        public DbSet<AdfsIntegrationConfiguration> AdfsIntegration { get; set; }
        public DbSet<SimpleHttpConfiguration> SimpleHttp { get; set; }
        public DbSet<DiagnosticsConfiguration> Diagnostics { get; set; }
        public DbSet<ClientCertificates> ClientCertificates { get; set; }
        public DbSet<Delegation> Delegation { get; set; }
        public DbSet<RelyingParties> RelyingParties { get; set; }
        public DbSet<IdentityProvider> IdentityProviders { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<CodeToken> CodeTokens { get; set; }
       
        #endregion

        #region Membership provider entities
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        #endregion


        #region Data Tables
        public DbSet<CaseRecord> CaseRecords { get; set; }
        public DbSet<Child> Children { get; set; }
        public DbSet<CourtCase> CourtCases { get; set; }
        public DbSet<CourtParty> CourtParties { get; set; }
        public DbSet<OtherProtected> OtherProtected { get; set; }
        public DbSet<Attorney> Attorneys { get; set; }
        public DbSet<Interpreter> Interpreters { get; set; }
        public DbSet<Witness> Witnesses { get; set; }
        public DbSet<CaseHistory> CaseHistory { get; set; }
        public DbSet<Hearing> Hearings { get; set; }
        public DbSet<CaseNote> CaseNotes { get; set; }
        public DbSet<CourtCaseOrder> CourtCaseOrders { get; set; }
        public DbSet<CourtMember> CourtMembers { get; set; }
        public DbSet<CourtDepartment> CourtDepartments { get; set; }
        public DbSet<FACCTSConfiguration> FACCTSConfiguration { get; set; }
        public DbSet<ManualIntegrationTask> ManualIntegrationTasks { get; set; }
        public DbSet<ScheduledIntegrationTask> ScheduledIntegrationTasks { get; set; }
        #endregion

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}
