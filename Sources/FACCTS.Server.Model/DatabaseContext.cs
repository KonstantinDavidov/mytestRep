using FACCTS.Server.Common;
using FACCTS.Server.Model.DataModel.Configuration;
using System;
using System.ComponentModel.Composition;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace FACCTS.Server.Model.DataModel
{
    [Export(typeof(IDatabaseContext))]
    public partial class DatabaseContext : DbContext, IDatabaseContext
    {

        public DatabaseContext()
            : base("name=FACCTS_DB")
        {

        }

        public DatabaseContext(DbConnection dbConn) : base(dbConn, true)
        {

        }

        public DatabaseContext(IDatabaseInitializer<DatabaseContext> initializer)
        {
            Database.SetInitializer<DatabaseContext>(initializer);
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

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}
