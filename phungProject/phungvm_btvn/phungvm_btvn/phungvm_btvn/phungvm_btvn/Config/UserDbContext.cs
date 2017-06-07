using phungvm_btvn.Models;
using System.Data.Entity;


namespace phungvm_btvn
{
    public class UserDbContext : System.Data.Entity.DbContext
    {
        public UserDbContext()
            : base()
        {
            this.Database.Connection.ConnectionString = "Data Source=ODA\\ODA;Initial Catalog=UserManagement;Integrated Security=SSPI;User ID=ODA\\Odarino";
            this.Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer(new System.Data.Entity.MigrateDatabaseToLatestVersion<UserDbContext, Configuration>());
            Database.SetInitializer<UserDbContext>(new CreateDatabaseIfNotExists<UserDbContext>());
            //Database.SetInitializer<PickupContext>(new DropCreateDatabaseIfModelChanges<PickupContext>());
            //Database.SetInitializer<PickupContext>(new DropCreateDatabaseAlways<PickupContext>());
            //Database.SetInitializer<MessagingContext>(new MessagingInitializer());
        }

        public DbSet<User> User { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Session> Session { get; set; }
    }

    public class Configuration : System.Data.Entity.Migrations.DbMigrationsConfiguration<UserDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(UserDbContext context)
        {
            context.Database.Connection.ConnectionString = ConnectionString();
        }
        public static string ConnectionString()
        {
            return "Data Source=TEMP-PHUNGVM\\SHAREPOINT;Initial Catalog=UserManagement;Integrated Security=SSPI;User ID=FSOFT.FPT.VN\\PHUNGVM";
        }
    }
}