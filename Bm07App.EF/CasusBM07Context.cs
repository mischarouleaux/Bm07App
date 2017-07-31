//using System.Data.Entity;
//using System.Data.Entity.Infrastructure;
//using Bm07App.EF.Models.Mapping;
//
//namespace Bm07App.EF.Models
//{
//    public partial class CasusBM07Context : DbContext
//    {
//        static CasusBM07Context()
//        {
//            Database.SetInitializer<CasusBM07Context>(null);
//        }
//
//        public CasusBM07Context()
//            : base("Name=CasusBM07Context")
//        {
//        }
//
//        public DbSet<Activity> Activities { get; set; }
//        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
//        public DbSet<ApplicationUserClient> ApplicationUserClients { get; set; }
//        public DbSet<ApplicationUserGroup> ApplicationUserGroups { get; set; }
//        public DbSet<Case> Cases { get; set; }
//        public DbSet<Client> Clients { get; set; }
//        public DbSet<ClientNote> ClientNotes { get; set; }
//        public DbSet<Competance> Competances { get; set; }
//        public DbSet<EmailToken> EmailTokens { get; set; }
//        public DbSet<ICF> ICFs { get; set; }
//        public DbSet<MedicalField> MedicalFields { get; set; }
//        public DbSet<Observation> Observations { get; set; }
//        public DbSet<ObservationRow> ObservationRows { get; set; }
//        public DbSet<Participation> Participations { get; set; }
//        public DbSet<SessionToken> SessionTokens { get; set; }
//        public DbSet<UserGroup> UserGroups { get; set; }
//        public DbSet<database_firewall_rules> database_firewall_rules { get; set; }
//
//        protected override void OnModelCreating(DbModelBuilder modelBuilder)
//        {
//            modelBuilder.Configurations.Add(new ActivityMap());
//            modelBuilder.Configurations.Add(new ApplicationUserMap());
//            modelBuilder.Configurations.Add(new ApplicationUserClientMap());
//            modelBuilder.Configurations.Add(new ApplicationUserGroupMap());
//            modelBuilder.Configurations.Add(new CaseMap());
//            modelBuilder.Configurations.Add(new ClientMap());
//            modelBuilder.Configurations.Add(new ClientNoteMap());
//            modelBuilder.Configurations.Add(new CompetanceMap());
//            modelBuilder.Configurations.Add(new EmailTokenMap());
//            modelBuilder.Configurations.Add(new ICFMap());
//            modelBuilder.Configurations.Add(new MedicalFieldMap());
//            modelBuilder.Configurations.Add(new ObservationMap());
//            modelBuilder.Configurations.Add(new ObservationRowMap());
//            modelBuilder.Configurations.Add(new ParticipationMap());
//            modelBuilder.Configurations.Add(new SessionTokenMap());
//            modelBuilder.Configurations.Add(new UserGroupMap());
//            modelBuilder.Configurations.Add(new database_firewall_rulesMap());
//        }
//    }
//}

using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using Bm07App.EF.Mapping;
using Bm07App.Models;

namespace Bm07App.EF
{
    public partial class CasusBM07Context : DbContext
    {
        static CasusBM07Context()
        {
            Database.SetInitializer<CasusBM07Context>(null);
        }

        public CasusBM07Context(string connectionString) : base(connectionString)
        {
            // Do NOT enable proxied entities, else serialization fails
            Configuration.ProxyCreationEnabled = false;

            // We don't do lazy loading due to unexpected queries being fired on the front end.
            Configuration.LazyLoadingEnabled = false;
        }

        public CasusBM07Context()
            : base("Name=CasusBM07Context")
        {
            // Do NOT enable proxied entities, else serialization fails
            Configuration.ProxyCreationEnabled = false;

            // We don't do lazy loading due to unexpected queries being fired on the front end.
            Configuration.LazyLoadingEnabled = false;
        }

        public static CasusBM07Context Create()
        {
            return new CasusBM07Context();
        }

        public IDbSet<Activity> Activities { get; set; }
        public IDbSet<ApplicationUser> ApplicationUsers { get; set; }
        public IDbSet<ApplicationUserClient> ApplicationUserClients { get; set; }
        public IDbSet<ApplicationUserGroup> ApplicationUserGroups { get; set; }
        public IDbSet<Case> Cases { get; set; }
        public IDbSet<Client> Clients { get; set; }
        public IDbSet<ClientNote> ClientNotes { get; set; }
        public IDbSet<Competance> Competances { get; set; }
        public IDbSet<EmailToken> EmailTokens { get; set; }
        public IDbSet<ICF> ICFs { get; set; }
        public IDbSet<MedicalField> MedicalFields { get; set; }
        public IDbSet<Observation> Observations { get; set; }
        public IDbSet<ObservationRow> ObservationRows { get; set; }
        public IDbSet<Participation> Participations { get; set; }
        public IDbSet<SessionToken> SessionTokens { get; set; }
        public IDbSet<UserGroup> UserGroups { get; set; }
        public IDbSet<database_firewall_rules> database_firewall_rules { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Call our base, needed for Identity related stuff.
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Remove this convention, we don't do a cascade delete all too often and if we need to, we'll handle it ourselves.
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            {
                modelBuilder.Configurations.Add(new ActivityMap());
                modelBuilder.Configurations.Add(new ApplicationUserMap());
                modelBuilder.Configurations.Add(new ApplicationUserClientMap());
                modelBuilder.Configurations.Add(new ApplicationUserGroupMap());
                modelBuilder.Configurations.Add(new CaseMap());
                modelBuilder.Configurations.Add(new ClientMap());
                modelBuilder.Configurations.Add(new ClientNoteMap());
                modelBuilder.Configurations.Add(new CompetanceMap());
                modelBuilder.Configurations.Add(new EmailTokenMap());
                modelBuilder.Configurations.Add(new ICFMap());
                modelBuilder.Configurations.Add(new MedicalFieldMap());
                modelBuilder.Configurations.Add(new ObservationMap());
                modelBuilder.Configurations.Add(new ObservationRowMap());
                modelBuilder.Configurations.Add(new ParticipationMap());
                modelBuilder.Configurations.Add(new SessionTokenMap());
                modelBuilder.Configurations.Add(new UserGroupMap());
                modelBuilder.Configurations.Add(new database_firewall_rulesMap());

            }
        }
    }
}
