using CoinFac.Domain.Accounts;
using CoinFac.Domain.Identity;
using CoinFac.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace CoinFac.Persistence
{
    /// <summary>
    /// To add migration
    /// cd .\Persistence
    /// dotnet ef --startup-project ../Presentation/ migrations add InitialDbMigration
    /// dotnet ef database update -s ../CoinFac.Presentation
    /// </summary>
    public class DatabaseService : DbContext
    {
        private readonly IConfiguration _config;

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<User> Users { get; set; }

        public DatabaseService(DbContextOptions options, IConfiguration config) : base(options) //base("CleanArchitecture")
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("CoinFacDb"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new RecordConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

        public void Save()
        {
            this.SaveChanges();
        }
    }
}
